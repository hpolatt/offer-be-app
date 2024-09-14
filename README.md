## .Net 8 BE API with Onion Architecture. 

Install | Deployment 
-> You need a Postgre Database and fill the configuration of database to appsettings.Development.json/appsettings.Production.json
-> please run the migration command to terminal 
  -> go to QuotationSystem.Persistence folder
  -> dotnet ef migrations add InitialMigration --startup-project ../QuotationSystem.API --context AppDbContext
  -> dotnet ef database update --startup-project ../QuotationSystem.API --context AppDbContext

