## :wrench: Migrations

```bash
$ cd src/
$ cd pmBudget.Infrastructure/

# Generate Migration
$ dotnet ef --startup-project ../pmBudget.API/ migrations add [name]

# Apply Migration
$ dotnet ef --startup-project ../pmBudget.API/ database update
```