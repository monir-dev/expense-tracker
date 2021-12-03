using ExpenseTracker.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [DateGreaterThanOrEqualToday]
        [Display(Name = "Expanse Date")]
        public DateTime ExpanseDate { get; set; }

        [Required]
        [Range(double.Epsilon, double.MaxValue)]
        [Display(Name = "Expanse Amount")]
        public double  Amount { get; set; }

        public Category Category { get; set; }
    }
}
