# Simple Expense Tracker
## Category wise track your expenses.
### This is a dotnet 5 mvc project
 
## Instructions
-  Change database server ip, databse name from appsetting.json file.

-  If you are using visual studio
   - Then open package manager console and run this command for database migration: ```Update-Database```
   - Now you can run the project as usual


-  If you want run projcet by command line
   - then browse /src/ExpenseTracker this folder in cmd
   - then run this command for database migration: ```dotnet ef database update```
   - run this command if dotnet ef not installed: ```dotnet tool update --global dotnet-ef```
   - now you can run the project by this command: ```dotnet run```

### When you run the project for the first time it will seed some sample data.
