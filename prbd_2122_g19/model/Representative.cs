using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prbd_2122_g19.model {
     public enum Type { Proxy,Holder};
    public class Representative : EntityBase<BankContext> {
      
        public int ClientId { get; set; }
        [Required]
        public virtual Client Client { get; set; }
        public string InternalAccountIban { get; set; }
        [Required]
        public virtual InternalAccount InternalAccount { get; set; }
        
        public Type Type { get; set; }
        public Representative(Client client,InternalAccount internalAccount,Type type) {
            InternalAccount = internalAccount;
            Client = client;
            Type = type;
        }
        protected Representative() { }

        public static IQueryable<Representative> GetAll(User user) {
           var query=from a in Context.Representatives 
                     where a.Client.User_id == user.User_id 
                     orderby a.InternalAccount.Description 
                     select a;
            return query;
        }
        public static IQueryable<Representative> GetToMyAccounts(User user, InternalAccount internalAccount) {
            var query = from a in GetAll(user)
                        where a.InternalAccount.Iban != internalAccount.Iban 
                        select a;
            return query;
        }
        public static IQueryable<Representative> GetToOtherAccounts(User user, InternalAccount internalAccount) {
            var query = from a in Context.Representatives
                        where a.InternalAccountIban != internalAccount.Iban && a.ClientId != user.User_id
                        select a;
            return query;
        }
        public static IQueryable<Representative> GetFiltered(string Filter,User user) {
            var filtered = from a in Representative.GetAll(user)
                           where a.InternalAccountIban.Contains(Filter) || a.InternalAccount.Description.Contains(Filter)
                           orderby a.InternalAccount.Description
                           select a;
            return filtered;
        }


    }
    
}
