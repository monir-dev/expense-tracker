using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ExpenseContext context)
        {
            context.Database.EnsureCreated();

            if (context.Categories.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category{ Name = "House Rent" },
                new Category{ Name = "Water Bill" },
                new Category{ Name = "Electric Bill" },
                new Category{ Name = "Groceries" },
                new Category{ Name = "Uber" },
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();

            var expenses = new Expense[]
            {
                new Expense{ CategoryId = 1, ExpanseDate = DateTime.Now, Amount = 20000 },
                new Expense{ CategoryId = 2, ExpanseDate = DateTime.Now, Amount = 1000 },
                new Expense{ CategoryId = 3, ExpanseDate = DateTime.Now, Amount = 1500 },
                new Expense{ CategoryId = 4, ExpanseDate = DateTime.Now, Amount = 6500 },
                new Expense{ CategoryId = 5, ExpanseDate = DateTime.Now, Amount = 350 },
            };

            context.Expenses.AddRange(expenses);
            context.SaveChanges();
        }
    }
}
