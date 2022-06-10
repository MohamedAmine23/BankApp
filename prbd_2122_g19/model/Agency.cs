using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prbd_2122_g19.model {
    public class Agency {
        [Key]
        public int AgencyId { get; set; }
        [Required]
        public string Name { get; set; }
        public int ManagerId { get; set; }
        [Required]
        public virtual Manager Manager { get; set; }

        public virtual ICollection<Client> Clients{ get; set;} = new HashSet<Client>();
        public Agency(string name, Manager manager) {
            Name = name;
            Manager = manager;
        }
        protected Agency() { }
    }
}

