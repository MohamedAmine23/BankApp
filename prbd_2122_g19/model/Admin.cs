using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prbd_2122_g19.model {
    public class Admin : User {
        public Admin(string firstName, string name, string email, string password) : base(firstName,name,email,password) {

        }
   
        protected Admin() { }
    }
}
