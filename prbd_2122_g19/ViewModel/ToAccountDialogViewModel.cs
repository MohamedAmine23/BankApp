using prbd_2122_g19.model;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace prbd_2122_g19.ViewModel {
    public class ToAccountDialogViewModel : DialogViewModelBase<User, BankContext> {
        public ICommand Ok { get; set; }
        public ICommand Cancel { get; set; }
        private string _filter;
        public string Filter { get => _filter; set => SetProperty(ref _filter, value, OnRefreshData); }
        private Representative _accountSelected;
        public Representative AccountSelected{ get => _accountSelected; set => SetProperty(ref _accountSelected, value, () => Console.WriteLine("account selected" + _accountSelected)); }
        private Representative _fromAccount;

        public Representative FromAccount { get => _fromAccount; set => SetProperty(ref _fromAccount, value); }
        public ObservableCollection<Representative> _myAccounts;
        public ObservableCollection<Representative> _otherAccounts;
        public ObservableCollection<Representative> MyAccounts { get=>_myAccounts; set=>SetProperty(ref _myAccounts,value); }
        public ObservableCollection<Representative> OtherAccounts { get => _otherAccounts; set => SetProperty(ref _otherAccounts, value); }
        public ToAccountDialogViewModel() {
            Ok = new RelayCommand(SaveAction, CanSaveAction);
        
        }
        public override void  SaveAction() {
            if (AccountSelected != null) {
                DialogResult = AccountSelected;
            }
        }
        private bool CanSaveAction() {
            return AccountSelected!=null;
        }
        public void Init(Representative rep) {
            FromAccount = rep;
            Console.WriteLine(rep.InternalAccountIban);
            MyAccounts = new ObservableCollection<Representative>(Representative.GetToMyAccounts(CurrentUser, FromAccount.InternalAccount));
            OtherAccounts = new ObservableCollection<Representative>(Representative.GetToOtherAccounts(CurrentUser, FromAccount.InternalAccount));

        }
        protected override void OnRefreshData() {
            var myaccountFiltered = from a in Representative.GetToMyAccounts(CurrentUser, FromAccount.InternalAccount) where a.InternalAccountIban.Contains(Filter) || a.InternalAccount.Description.Contains(Filter) select a;
            var otherAccountFilter = from a in Representative.GetToOtherAccounts(CurrentUser, FromAccount.InternalAccount) where a.InternalAccountIban.Contains(Filter) || a.InternalAccount.Description.Contains(Filter) select a;
            MyAccounts= new ObservableCollection<Representative>(myaccountFiltered);
            OtherAccounts = new ObservableCollection<Representative>(otherAccountFilter);
        }
    }
}
