using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using PRBD_Framework;

namespace prbd_2122_g19.model {
    public abstract class User : EntityBase<BankContext> {
        [Key]
        public int User_id { get; set; } 
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FirstName { get; set; }
        
       
        
        public virtual ICollection<Transfer> Transfers { get; set; } = new HashSet<Transfer>();
        public User(string firstName,string name,string email,string password) {
            FirstName = firstName;
            Name = name;
            Email = email;
            Password = password;


        }

        protected User() { }
        public static User GetByEmail(string email) {
            return Context.Users.SingleOrDefault(u => u.Email == email);
        }
    }
}
