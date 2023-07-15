# Congestion Tax Calculator

This Repository is based in Clean architecture and consists of six projects : Domain, EFCore, Infrastructure, Application an Application.Contracts with XUnitTest project.


## Whats Including In This Repository
I have implemented below 

#### CongestionTaxCalculator.Domain which includes; 
* This is Domain Defination of Congestion Tax Calculator.In this project the Persistence namespace implemented Persiste Model to store flexible Tariff definition in Microsoft SQL Server database.. 
The conection string stored in CongestionTaxCalculator.EFCore in appsettings.js.
I can not find any entity in Congestion Tax Calculator problem. The whole tariff definition is stored by the value object concept in DDD. Implementation the logic of problem with value object makes my code clearer and  maintenanceable.
value objects of Congestion Tax Calculator are store in Model namespace.


#### CongestionTaxCalculator.EFCore which includes; 
* Context Class
* Context database Seed method
* Migrations folder
* Repository implementation

#### CongestionTaxCalculator.Infrastructure which includes; 
*Implement some utils

#### CongestionTaxCalculator.Application which includes; 
*Implement Application Layer. It has two services: TariffAppService , CongestionTaxAppService

#### CongestionTaxCalculator.Application.Contracts which includes; 
*Implement Dto models


#### CongestionTaxCalculator.Test which includes; 
* Test Project to Test TariffAppService , CongestionTaxAppService

## Run The Project
You will need the following tools to running XUnit Test Project (The Tet projec use Mocking):

* [Visual Studio 2022 or later](https://visualstudio.microsoft.com/downloads/)
* [.Net Core 6 or later](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)




## Practices and patterns:

- [TDD]
- [DDD]
- [BDD]
- [Clean architecture]
- git commits show my work progress.



