using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using prbd_2122_g19.model;
using PRBD_Framework;

namespace prbd_2122_g19.ViewModel {
    public class MainViewModel:ViewModelCommon {
        public ObservableCollectionFast<User> Users { get; set; } = new ObservableCollectionFast<User>();
        public ICommand ReloadDataCommand { get; set; }
        public static InternalAccount CurrentAccount { get; set; }
        private DateTime _dateChange;
        public DateTime DateChange {
            get => _dateChange;
            set {
                _dateChange = value;
                App.CurrentDate = value;
                NotifyColleagues(App.Messages.MSG_REFRESH_ACCOUNTS);
                NotifyColleagues(App.Messages.MSG_REFRESH_TRANSFERS, CurrentAccount);
            }
        }
            public MainViewModel() : base() {
            DateChange = App.CurrentDate;
                
                ReloadDataCommand = new RelayCommand(() => {
                    // refuser un reload s'il y a des changements en cours
                    if (Context.ChangeTracker.HasChanges()) return;
                    // permet de renouveller le contexte EF  
                    App.ClearContext();
                    // notifie tout le monde qu'il faut rafraîchir les données
                    NotifyColleagues(ApplicationBaseMessages.MSG_REFRESH_DATA);
                });
            }

        public static string Title {

            get {
                string _curUser="";
                if (IsClient) {
                    _curUser = "Client";
                }
                else if (IsAdmin) {
                    _curUser = "Admin";
                }
                else if (IsManager) {
                    _curUser = "Manager";
                }
                return $"MyBank({CurrentUser?.Email}-{_curUser})" ;
            }
                
        }

    }
}
