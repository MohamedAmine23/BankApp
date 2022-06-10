using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace prbd_2122_g19.model {
	public enum AccountType {Checking,Saving }
    public  abstract class InternalAccount : Account {
		public AccountType AccountType { get => this is CheckingAccount ? AccountType.Checking : AccountType.Saving; }
		public double Floor { get; set; }
		public virtual ICollection<Representative> Representatives { get; set; } = new HashSet<Representative>();
		protected InternalAccount(string iban, string description, double floor) : base(iban,description)
		{
			Floor = floor;
		}
		protected InternalAccount( string description, double floor) : base(description) {
			Floor = floor;
		}
		public InternalAccount() { }
		public static IQueryable<InternalAccount> GetAll() {
			return Context.InternalAccounts.OrderBy(a => a.Description);
		}
		[NotMapped]
		public double Solde 
			{ 
			get =>GetSolde(App.CurrentDate);
            set {
				Solde = value;
				}
			}

			
		
		public double GetSolde(DateTime todayDate) {
			double solde = 0.0;
			DateTime dateOk;
			ICollection<Transfer> ls = new HashSet<Transfer>(Transfer.GetAllfromAccount(this));
			foreach(var r in ls ) {
				
                if (r.EffectiveDate == null) {
					dateOk = r.CreationDate;
                } else {
					dateOk =(DateTime)r.EffectiveDate;
                }
                if (dateOk <= todayDate) {
                    if (r.CreditAccount.Iban == this.Iban) {
						solde += r.Amount;
                    }
                    else if (r.DebitAccount.Iban == this.Iban) {
                        if (solde - r.Amount >= this.Floor) {
							solde -= r.Amount;

                        } else {

                        }
                    }
                }
				
            }
			//Console.WriteLine(solde);
			return solde;
        }
		public static IQueryable<InternalAccount> GetFiltered(string Filter) {
			var filtered = from a in Context.InternalAccounts
						   where a.Iban.Contains(Filter) || a.Description.Contains(Filter)
						   orderby a.Description
						   select a;
			return filtered;
		}
	}
}

