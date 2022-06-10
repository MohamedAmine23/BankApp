using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using PRBD_Framework;
using System.ComponentModel.DataAnnotations.Schema;
using prbd_2122_g19.ViewModel;
namespace prbd_2122_g19.model {
    //public enum State { Invalid,Valid,Neutre}
    public class Transfer : EntityBase<BankContext> {
        [Key]
        public int TransferId { get; set; }
        [Required, ForeignKey(nameof(DebitAccount))]
        public string DebitAccountIban { get; set; }
        [Required]
        public virtual Account DebitAccount { get; set; }
        [Required, ForeignKey(nameof(CreditAccount))]
        public string CreditAccountIban { get; set; }
        [Required]
        public virtual Account CreditAccount { get; set; }

        public double Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public int? UserId { get; set; }
        //public State State { get; set; }
        public virtual User Owner { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Communication { get; set; }
        [NotMapped]
        public double AmountSigned => getSign();

        [NotMapped]
        public double CurrentSolde => getCurrentSolde();
        [NotMapped]
        public bool IsFutur => EffectiveDate > App.CurrentDate && MainViewModel.CurrentAccount.Iban==DebitAccountIban;
        [NotMapped]
        public bool IsPresent => EffectiveDate <= App.CurrentDate;
        [NotMapped]
        public bool IsRefused => refused();
        private bool refused() {
            if (DebitAccount is InternalAccount && MainViewModel.CurrentAccount.Iban == DebitAccountIban) {
               var Accountdebited = (InternalAccount)DebitAccount;
                return Accountdebited.GetSolde(App.CurrentDate) - Amount <= Accountdebited.Floor && App.CurrentDate >= EffectiveDate;
            } else if (DebitAccount is InternalAccount){
                return false;
            }
            return false;
        }
        private double getCurrentSolde() {
            DateTime dateOk;
            double solde; 
            if (EffectiveDate == null) {
                dateOk = CreationDate;
            } else {
                dateOk = (DateTime)EffectiveDate;
            }
            solde = MainViewModel.CurrentAccount.GetSolde(dateOk);
            return solde;
        }
        private double getSign() {
            double amount;
            if (MainViewModel.CurrentAccount.Iban == DebitAccountIban) {
                amount = Amount * (-1);
            } else {
                amount = Amount;
            }
            return amount;   

        }





        public Transfer(Account debitAccount,Account creditAccount, double amount,string communication,DateTime creationDate,
              
            DateTime? effectiveDate,User owner=null,Category category=null) {
            Category = category;
            Amount = amount;
            Communication = communication;
            CreationDate = creationDate;
            EffectiveDate = effectiveDate;
            Owner = owner;
            CreditAccount = creditAccount;
            DebitAccount = debitAccount;
           
            debitAccount.TransfersDebited.Add(this);
            creditAccount.TransfersCredited.Add(this);
            
        }
        public Transfer() { }
        public static IQueryable<Transfer> GetAllfromAccount(InternalAccount account) {
            var query = from t in Context.Transfers
                        where t.CreditAccountIban == account.Iban || t.DebitAccountIban == account.Iban
                       orderby t.EffectiveDate descending,t.CreationDate descending
                        select t;
            return query;
        }
        public static IQueryable<Transfer> GetFilteredfromAccount(InternalAccount account,string Filter) {
            var query = from t in GetAllfromAccount(account)
                        where t.Communication.Contains(Filter)
                        
                        || t.CreditAccountIban.Contains(Filter)
                        || t.DebitAccountIban.Contains(Filter)

                        || t.CreditAccount.Description.Contains(Filter)
                        || t.DebitAccount.Description.Contains(Filter)
                        
                        || t.Owner.FirstName.Contains(Filter)
                        || t.Owner.Name.Contains(Filter)
                        
              
                        select t;
            return query;
        }


    }


}
