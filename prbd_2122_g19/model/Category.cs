using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prbd_2122_g19.model {
    public class Category:EntityBase<BankContext> {
      
        public int CategoryId { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public  bool IsChecked { get; set; }
        public virtual ICollection<Transfer> Transfers { get; set; } = new HashSet<Transfer>();
        public Category(string name) {
            Name = name;
        }
        public Category() { }
        public static IQueryable<Category> GetAll() {
            return Context.Categories;
        }
    }
}
