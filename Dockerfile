FROM ubuntu:20.04

# Install necessary tools and dependencies
RUN apt-get update \
    && apt-get install -y curl gnupg \
    && curl -sL https://deb.nodesource.com/setup_14.x | bash - \
    && apt-get install -y nodejs \
    && apt-get install -y git \
    && apt-get install -y build-essential \
    && apt-get install -y libssl-dev \
    && apt-get install -y libcurl4-openssl-dev \
    && apt-get install -y libicu-dev \
    && apt-get install -y libxml2-dev \
    && apt-get install -y libpng-dev \
    && apt-get install -y libjpeg-dev \
    && apt-get install -y libgif-dev \
    && apt-get install -y libfontconfig \
    && rm -rf /var/lib/apt/lists/*

# Install .NET Core SDK
RUN curl -sL https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -o packages-microsoft-prod.deb \
    && dpkg -i packages-microsoft-prod.deb \
    && rm packages-microsoft-prod.deb \
    && apt-get update \
    && apt-get install -y dotnet-sdk-6.0

# Install Angular CLI
RUN npm install -g @angular/cli

# Copy application source code
WORKDIR /app
COPY . .

# Build .NET Core application
WORKDIR /app/api
RUN dotnet restore \
    && dotnet publish -c Release -o out

# Build Angular app
WORKDIR /app/client
RUN npm install \
    && ng build --prod

# Expose ports for the app to run
EXPOSE 80
EXPOSE 443
EXPOSE 8090

# Start the application
WORKDIR /app/api/out
CMD ["dotnet", "api.dll"]
