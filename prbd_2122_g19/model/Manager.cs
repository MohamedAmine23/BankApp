using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prbd_2122_g19.model {
    public class Manager : User {
        public virtual ICollection<Agency> Agencies { get; set; } = new HashSet<Agency>();
        public Manager(string firstName, string name, string email, string password) : base(firstName, name, email, password) {

        }
   
        protected Manager() { }

     
        
    }
}
