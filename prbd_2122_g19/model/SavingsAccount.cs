using System;
using System.Linq;

namespace prbd_2122_g19.model {
    public class SavingsAccount : InternalAccount {
        public SavingsAccount(string iban,string description) : base(iban,description,0) {
        }
        public SavingsAccount( string description) : base(description, 0) {
        }
        protected SavingsAccount() { }

        public new static  IQueryable<SavingsAccount> GetFiltered(string Filter) {
            var filtered = from a in Context.SavingsAccounts
                           where a.Iban.Contains(Filter) || a.Description.Contains(Filter)
                           orderby a.Description
                           select a;
            return filtered;
        }
    }
}
