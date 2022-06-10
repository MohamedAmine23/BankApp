using prbd_2122_g19.model;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace prbd_2122_g19.ViewModel {
    class TransferDetailViewModel : ViewModelCommon {
        private Representative _currentRepresentative;
        public Representative CurrentRepresentative { get=>_currentRepresentative; set=>SetProperty(ref _currentRepresentative,value); }
        private double _amount;
        public double Amount { get => _amount; set => SetProperty(ref _amount, value); }
        private string _communication;
        public string Communication { get => _communication; set => SetProperty(ref _communication, value); }
        private DateTime? _effectiveDate;
        public DateTime? EffectiveDate { get=>_effectiveDate; set=>SetProperty(ref _effectiveDate,value); }
        private ObservableCollectionFast<Category> _categories;
        public ObservableCollectionFast<Category> Categories { get=>_categories; set=>SetProperty(ref _categories,value); }
        private Category _selectedCategory;
        public Category SelectedCategory { get=>_selectedCategory; set=>SetProperty(ref _selectedCategory,value); }
        public ObservableCollectionFast<Representative> Accounts { get; set; }
        private Representative _selectedToAccount;
        public Representative SelectedToAccount { get => _selectedToAccount; set => SetProperty(ref _selectedToAccount, value); }
        private Representative _selectedAccount;
        public Representative SelectedAccount{ get => _selectedAccount; set => SetProperty(ref _selectedAccount, value); }
        public ICommand ApplyTransfer{ get; set; }
        public ICommand ShowAllAccounts { get; set; }
        public ICommand Cancel { get; set; }
        public Transfer Transfer { get; set; }
        public TransferDetailViewModel() : base() {
            Accounts = new ObservableCollectionFast<Representative> (Representative.GetAll(CurrentUser));
            Categories = new ObservableCollectionFast<Category>(Category.GetAll());

            ShowAllAccounts = new RelayCommand<Representative>(rep => { SelectedToAccount=(Representative) App.ShowDialog<ToAccountDialogViewModel, User, BankContext>(SelectedAccount); });
            Cancel = new RelayCommand(CancelAction);
            ApplyTransfer = new RelayCommand(TransferAction, CanTransferAction);
        }
        public void TransferAction() {
            if (Validate()) {
                if (EffectiveDate == null) {
                    EffectiveDate = App.CurrentDate;
                }
                Transfer = new Transfer(SelectedAccount.InternalAccount, SelectedToAccount.InternalAccount, Amount, Communication,App.CurrentDate,EffectiveDate,CurrentUser,SelectedCategory);
                Context.Add(Transfer);
           
            Context.SaveChanges();
            NotifyColleagues(App.Messages.MSG_REFRESH_ACCOUNTS);
            NotifyColleagues(App.Messages.MSG_REFRESH_TRANSFERS,SelectedAccount.InternalAccount);
            NotifyColleagues(App.Messages.MSG_REFRESH_TRANSFERS,SelectedToAccount.InternalAccount);
            NotifyColleagues(App.Messages.MSG_CLOSE_TAB,CurrentRepresentative); 
            }
        }
        public bool CanTransferAction() {
            return Validate();
        }
        public override void CancelAction() {
            ClearErrors();
            NotifyColleagues(App.Messages.MSG_CLOSE_TAB, CurrentRepresentative);
            RaisePropertyChanged();
        }
        public override bool Validate() {
            ClearErrors();

           
            if (Amount<= 0)
                AddError(nameof(Amount), " Amount required");
            if (string.IsNullOrEmpty(Communication))
                AddError(nameof(Communication), " Communication required");
            if (EffectiveDate < App.CurrentDate)
                AddError(nameof(EffectiveDate), "can not be in past");
            if (EffectiveDate == null&& SelectedAccount!=null) {
                if (SelectedAccount.InternalAccount.GetSolde(App.CurrentDate)-Amount<SelectedAccount.InternalAccount.Floor)
                AddError(nameof(Amount), "not enough money ");
            }
            return !HasErrors;
        }
        
        public void Init( Representative representative) {
            CurrentRepresentative = representative;
            SelectedAccount = CurrentRepresentative;
        }
    }
}
