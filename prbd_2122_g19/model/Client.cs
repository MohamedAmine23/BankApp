using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prbd_2122_g19.model {
    public class Client : User {

        public virtual ICollection<Representative> Representatives { get; set; } = new HashSet<Representative>(); 
        public int AgencyId { get; set; }
        [Required]
        public virtual Agency Agency { get; set; }
        public Client(string firstName, string name, string email, string password, Agency agency) :
            base(firstName, name, email, password) {
            Agency = agency;
        }

        protected Client() { }

    }
}
