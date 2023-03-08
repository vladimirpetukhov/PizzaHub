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

#### NOTES
Not all functionalities are implemented. Somwere is missing validations
Missing messaging after successfull or not operation.
Missing full implementation of specifications
Unfortunatily I don't have a time to implement DB initializer but this is bettre to see if for real some of project functiolaties works
The project is based on Clean architecture nad DDD

HERE is full project history: https://github.com/vladimirpetukhov/PizzaHub it takes me arround 12 hours

