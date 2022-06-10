using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRBD_Framework;
using prbd_2122_g19.model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace prbd_2122_g19.ViewModel {
    class AccountsViewModel : ViewModelBase<User, BankContext> {
        public ICommand NewTransfer { get; set; }
        public ICommand DisplayStatements { get; set; }
        private ObservableCollection<Representative> _internalAccounts;
        public ObservableCollection<Representative> InternalAccounts {
            get => _internalAccounts;
            set => SetProperty(ref _internalAccounts, value, () => { });
        }

        
        public bool CheckingSelected { get => _checkingSelected; set => SetProperty(ref _checkingSelected, value,OnRefreshData); }
        public bool SavingsSelected { get => _savingsSelected; set => SetProperty(ref _savingsSelected, value, OnRefreshData); }
        private bool _savingsSelected;
        private bool _allSelected;
        private bool _checkingSelected;
       
        public bool AllSelected { get => _allSelected; set => SetProperty(ref _allSelected, value, OnRefreshData); }
        private string _filter;
        public string Filter { get => _filter; set => SetProperty(ref _filter, value, OnRefreshData); }
        public ICommand ApplyFilter { get; set; }
        public ICommand ClearFilter { get; set; }
        public AccountsViewModel():base() {

            Register(App.Messages.MSG_REFRESH_ACCOUNTS, () => {
                OnRefreshData();
            });
          
            ClearFilter = new RelayCommand(() => Filter = "");
            InternalAccounts = new ObservableCollection<Representative>(Representative.GetAll(CurrentUser));
            AllSelected = true;
            NewTransfer = new RelayCommand<Representative>(representative => NotifyColleagues(App.Messages.MSG_NEW_TRANSFER,representative));
            DisplayStatements=new RelayCommand<Representative>(representative => NotifyColleagues(App.Messages.MSG_DISPLAY_STATEMENTS, representative));
        }

        //private void checkGoodSoldes() {
        //    foreach(var a in InternalAccounts) {
        //        ICollection<Transfer> ls = new HashSet<Transfer>(Transfer.GetAllfromAccount(a.InternalAccount));
        //        foreach (var t in ls) {
        //            if (t.IsRefused) {
        //                a.InternalAccount.Solde = a.InternalAccount.Solde - t.Amount;
        //            }
        //        }
        //    }
            
        //}
        protected override void OnRefreshData() {
         //   checkGoodSoldes();
            if (CheckingSelected && SavingsSelected ||
                    CheckingSelected && _allSelected ||
                    SavingsSelected && _allSelected)
                return;
            IQueryable<Representative> accounts = string.IsNullOrEmpty(Filter) ? Representative.GetAll(CurrentUser) : Representative.GetFiltered(Filter,CurrentUser);
            var filteredMembers = from a in accounts
                                  where
                                 
                                      CheckingSelected && a.InternalAccount is CheckingAccount ||
                                     
                                      SavingsSelected && a.InternalAccount is SavingsAccount ||
                                    
                                      AllSelected
                                  select a;
            InternalAccounts = new ObservableCollection<Representative>(filteredMembers);
            Console.WriteLine("refreshaccounts");
        }

}
}
