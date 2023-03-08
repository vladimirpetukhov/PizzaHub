# PizzaHub

### Install mysql 
docker pull mysql
docker run --name my-mysql -p 3306:3306 -e MYSQL_ROOT_PASSWORD=abc123 -d mysql

### Install Api
cd api
dotnet restore
dotnet ef database update
dotnet watch run

### Install Client
cd client
npm i
npm start

