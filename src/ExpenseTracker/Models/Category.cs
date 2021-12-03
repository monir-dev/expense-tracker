using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Expense> Expenses { get; set; }
    }
}
