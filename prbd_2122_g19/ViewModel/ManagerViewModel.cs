using prbd_2122_g19.model;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace prbd_2122_g19.ViewModel {
    class ManagerViewModel:ViewModelCommon {
        public ICommand ReloadDataCommand { get; set; }
        
        private DateTime _dateChange;
        public DateTime DateChange {
            get => _dateChange;
            set {
                _dateChange = value;
                App.CurrentDate = value;
            }
        }
        private Agency _selectedAgency;
        public Agency SelectedAgency { get => _selectedAgency; set => SetProperty(ref _selectedAgency, value,OnRefreshData); }
        public ObservableCollectionFast<Agency> Agencies { get; set; } = new();
        public ObservableCollectionFast<Client> Clients { get; set; } = new();
      
        public ManagerViewModel() : base() {
            DateChange = App.CurrentDate;

            ReloadDataCommand = new RelayCommand(() => {
                // refuser un reload s'il y a des changements en cours
                if (Context.ChangeTracker.HasChanges()) return;
                // permet de renouveller le contexte EF  
                App.ClearContext();
                // notifie tout le monde qu'il faut rafraîchir les données
                NotifyColleagues(ApplicationBaseMessages.MSG_REFRESH_DATA);
            });
            OnRefreshData();
            if (SelectedAgency != null) {
                ClientsOfAgency(SelectedAgency);
                Console.WriteLine("Agency");
            }
        }
        public static string Title {

            get {
                string _curUser = "";
                if (IsClient) {
                    _curUser = "Client";
                } else if (IsAdmin) {
                    _curUser = "Admin";
                } else if (IsManager) {
                    _curUser = "Manager";
                }
                return $"MyBank({CurrentUser?.Email}-{_curUser})";
            }

        }
        private void ClientsOfAgency(Agency agency) {
            if (agency != null) {
                Clients.RefreshFromModel(Context.Clients.Where(c => c.AgencyId == agency.AgencyId));
            }
        }
        protected override void OnRefreshData() {
            Agencies.RefreshFromModel(Context.Agencies.Where(a => a.Manager.User_id == CurrentUser.User_id));
            Console.WriteLine("selected:" + SelectedAgency);
            ClientsOfAgency(SelectedAgency);
            
        }


    }
        
}
