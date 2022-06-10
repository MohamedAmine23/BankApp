using System;
namespace prbd_2122_g19.model {
	public class ExternalAccount : Account {
	
		public ExternalAccount(string iban, string description) : base(iban,description) {
		}
		public ExternalAccount(string description) : base(description) {

        }
		protected ExternalAccount() { }
	}
}

