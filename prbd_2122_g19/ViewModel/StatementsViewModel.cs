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
    class StatementsViewModel:ViewModelCommon {
  
        public Representative Representative { get; set; }
        private bool _noCategorySelected;
        public bool NoCategorySelected { get => _noCategorySelected; set => SetProperty(ref _noCategorySelected, value, OnRefreshData); }
        private string _selectedPeriod;
        public string SelectedPeriod { get => _selectedPeriod; set => SetProperty(ref _selectedPeriod, value, OnRefreshData); }
        private bool _futurTransactionSelected;
        public bool FuturTransactionSelected { get => _futurTransactionSelected; set => SetProperty(ref _futurTransactionSelected, value, OnRefreshData); }
        private bool _pastTransactionSelected;
        public bool PastTransactionSelected { get => _pastTransactionSelected; set => SetProperty(ref _pastTransactionSelected, value, OnRefreshData); }

        private bool _refusedTransactionSelected;
        public bool RefusedTransactionSelected { get => _refusedTransactionSelected; set => SetProperty(ref _refusedTransactionSelected, value, OnRefreshData); }
        private string _filter;
        public string Filter { get => _filter; set => SetProperty(ref _filter, value, OnRefreshData); }
        public ICommand CheckAll { get; set; }
        public ICommand CheckNone { get; set; }
        public ICommand CancelTransfer { get; set; }
        //public string Signe => AmountValid() ? "-" : "+";

        public ObservableCollectionFast<string> Periods { get; set; }

        private ObservableCollectionFast<Transfer>_transfers;
        public ObservableCollectionFast<Transfer> Transfers {
            get => _transfers;
            set => SetProperty(ref _transfers, value);
        }
        private ObservableCollectionFast<Category> _categories;
        public ObservableCollectionFast<Category> Categories { get => _categories; set => SetProperty(ref _categories, value); }
        private void refreshCategories() {

            Categories.RefreshFromModel(Category.GetAll());
        }
        //private void checkGoodSoldes() {
        //    ICollection<Transfer> ls = new HashSet<Transfer>(Transfer.GetAllfromAccount(Representative.InternalAccount));
        //    foreach (var t in ls) {
        //        if (t.IsRefused) {
        //            Representative.InternalAccount.Solde = Representative.InternalAccount.Solde - t.Amount;
        //        }
        //    }
        //}
            
        public StatementsViewModel() : base() {
            Periods= new ObservableCollectionFast<string>(new[]{"All", "One day","One week","One month" });
            PastTransactionSelected = true;
            RefusedTransactionSelected = true;
            CancelTransfer = new RelayCommand<Transfer>((t) => {
                Context.Transfers.Remove(t);
                Context.SaveChanges();
                NotifyColleagues(App.Messages.MSG_REFRESH_TRANSFERS, t.DebitAccount);
               // NotifyColleagues(App.Messages.MSG_REFRESH_TRANSFERS, t.CreditAccount);
            });
             
            //SelectedPeriod = "All";
            Register<Account>(App.Messages.MSG_REFRESH_TRANSFERS, Account => {
                Transfers.RefreshFromModel(Context.Transfers.Where(t => t.CreditAccount.Iban == Account.Iban || t.DebitAccountIban == Account.Iban).OrderBy(t => t.EffectiveDate));
                OnRefreshData();
            });
            
            CheckAll = new RelayCommand(CheckAction);
            CheckNone = new RelayCommand(UncheckAction);
            Categories = new ObservableCollectionFast<Category>(Category.GetAll());
            
        }
          
        public void Init(Representative representative) {
            Representative = representative; 
            MainViewModel.CurrentAccount = Representative.InternalAccount;
            Transfers = new ObservableCollectionFast<Transfer>(Transfer.GetAllfromAccount(Representative.InternalAccount));
            


        }
        private void CheckAction() {

            foreach(var cat in Categories){
                cat.IsChecked = true;
            }
            NoCategorySelected = true;
            refreshCategories();
        
        }
        private void UncheckAction() {
            foreach (var cat in Categories) {
                cat.IsChecked = false;
            }
            NoCategorySelected = false;
            refreshCategories();

        }
        protected override void OnRefreshData() {
           // checkGoodSoldes();
           // Console.WriteLine(App.CurrentDate);
            if (PastTransactionSelected==false) {
                RefusedTransactionSelected = false;
            }
            else if (RefusedTransactionSelected) {
                PastTransactionSelected = true;
            }
            
            if (Representative!=null) {
                //  refreshCategories();
                //Console.WriteLine(App.CurrentDate);
                Console.WriteLine("selected:"+ SelectedPeriod);
                IQueryable<Transfer> transfers = string.IsNullOrEmpty(Filter) ?
                Transfer.GetAllfromAccount(Representative.InternalAccount) : Transfer.GetFilteredfromAccount(Representative.InternalAccount, Filter);
               // var filteredTransfers=transfers;
                //foreach (var cat in Categories) {
                //    if (cat.IsChecked) {
                      var  filteredTransfers = (from t in transfers where 
                                          //      FuturTransactionSelected && t.EffectiveDate > App.CurrentDate
                              //     || (PastTransactionSelected && t.EffectiveDate < App.CurrentDate)
                                    (NoCategorySelected && t.Category == null)
                                   ||  SelectedPeriod == "One day" && t.EffectiveDate >= App.CurrentDate.AddDays(-1)
                                   ||  SelectedPeriod == "One month" && t.EffectiveDate >= App.CurrentDate.AddMonths(-1)
                                   ||  SelectedPeriod == "One week" && t.EffectiveDate >= App.CurrentDate.AddDays(-7)
                                   //||   (t.CategoryId==cat.CategoryId)
                                   //|| (RefusedTransactionSelected&& t.IsRefused)
                                   //||(!RefusedTransactionSelected && t.IsRefused==false)
                                                 select t);
                   // }
              //  }
                Transfers = new ObservableCollectionFast<Transfer>(filteredTransfers);
                Console.WriteLine("onrefresh ok"+App.CurrentDate);
            }
            
        }
    }
}
