using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using PRBD_Framework;
using prbd_2122_g19.Model;

namespace prbd_2122_g19.model {
    public abstract class Account : EntityBase<BankContext> {
        
        [Key]
        public  string Iban { get; set; }
        //[Required]
        public string Description { get; set; }

        public virtual ICollection<Transfer> TransfersDebited { get; set; } = new HashSet<Transfer>();
        public virtual ICollection<Transfer> TransfersCredited { get; set; } = new HashSet<Transfer>();
        protected Account(string iban,string description) {
            Description = description;
            Iban = iban;
        }
        protected Account(string description) {
            Description = description;
            Iban = IBAN.Random();
        }
        public Account() {

        }
        

    }
}
