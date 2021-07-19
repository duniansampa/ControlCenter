#Pakage Manager
Enables these commonly used commands:
Add-Migration
Drop-Database
Get-DbContext
Get-Migration
Remove-Migration
Scaffold-DbContext
Script-Migration
Update-Database

#Console
#https://docs.microsoft.com/pt-br/ef/core/cli/dotnet
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef
dotnet ef migrations add  InitialCreate
dotnet ef database update
dotnet ef migrations list
dotnet ef migrations remove
dotnet ef migrations script
dotnet ef dbcontext script
dotnet ef dbcontext list
dotnet ef dbcontext info
dotnet ef dbcontext scaffold
dotnet ef database drop



