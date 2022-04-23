# GENERATE / APLLY MIGRATIONS

cd src/
cd pmBudget.Infrastructure/

dotnet ef --startup-project ../pmBudget.API/ migrations add MigrationName
dotnet ef --startup-project ../pmBudget.API/ database update
