using System;
using System.Linq;

namespace prbd_2122_g19.model {
public class CheckingAccount : InternalAccount
{
	public CheckingAccount(string iban, string description, double floor) : base(iban, description, floor)
	{
			
	}
	public CheckingAccount( string description, double floor) : base(description, floor) {

	}
		protected CheckingAccount() { }
		public new static IQueryable<CheckingAccount> GetFiltered(string Filter) {
			var filtered = from a in Context.CheckingAccounts
						   where a.Iban.Contains(Filter) || a.Description.Contains(Filter)
						   orderby a.Description
						   select a;
			return filtered;
		}
	}
}

