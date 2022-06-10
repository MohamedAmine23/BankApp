using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRBD_Framework;
using prbd_2122_g19.model;
using System.Windows.Input;

namespace prbd_2122_g19.ViewModel {
    class LoginViewModel : ViewModelCommon {
        
            private string _email;
            public string Email {
                get => _email;
                set => SetProperty(ref _email, value,()=>Validate());
            }
        private string _password;
        public string Password {
            get => _password;
            set => SetProperty(ref _password, value, () => Validate());
        }
        protected override void OnRefreshData() {
            }
        public ICommand LoginCommand { get; set; }
    
    public LoginViewModel() : base() {
            LoginCommand = new RelayCommand(LoginAction,
                () => { return _email != null && _password != null && !HasErrors; });
            Email = "bob@test.com";
            Password = "bob";
        }

        private void LoginAction() {
            if (Validate()) {
                var user = Context.Users.SingleOrDefault(x => x.Email == Email); ;
                NotifyColleagues(App.Messages.MSG_LOGIN, user);
            }
        }
        public override bool Validate() {
            ClearErrors();

            var user = Context.Users.SingleOrDefault(x => x.Email == Email);

            if (string.IsNullOrEmpty(Email))
                AddError(nameof(Email), "required");
            else if (Email.Length < 3)
                AddError(nameof(Email), "length must be >= 3");
            else if (user == null)
                AddError(nameof(Email), "does not exist");
            else if (user.Password != Password)
                AddError(nameof(Password), "password not correct");
            return !HasErrors;
        }

    }
}
