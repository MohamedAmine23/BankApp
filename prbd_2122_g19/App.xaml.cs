using prbd_2122_g19.model;
using PRBD_Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using prbd_2122_g19.ViewModel;
using System.Globalization;
using System.Windows.Markup;
using System.Text;
using prbd_2122_g19.Properties;

namespace prbd_2122_g19 {

    public partial class App : ApplicationBase<User, BankContext> {

        public enum Messages {
            MSG_LOGIN, MSG_LOGOUT, MSG_REFRESH_MESSAGES, MSG_NEW_TRANSFER, MSG_DISPLAY_STATEMENTS, MSG_CLOSE_TAB, MSG_REFRESH_ACCOUNTS, MSG_REFRESH_TRANSFERS

        }
        private static DateTime _currentdate = new DateTime(2022,01,12);
        public static DateTime CurrentDate {
            get => _currentdate; set {
                _currentdate = value;

            }
        }
        private void SetCulture() {
            // vérifie s'il existe une culture correspondant au paramètre "Locale"
            var culture = CultureInfo.GetCultures(CultureTypes.AllCultures)
                .SingleOrDefault(c => c.IetfLanguageTag.Equals(Settings.Default.Locale, StringComparison.OrdinalIgnoreCase));
            // spécifie la culture à utiliser pour le XAML
            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(
                    XmlLanguage.GetLanguage(
                        culture == null || culture.Name == "" ?
                            // la culture courante de Windows
                            CultureInfo.CurrentCulture.IetfLanguageTag :
                            // la culture spécifiée dans "Locale"
                            Settings.Default.Locale)));
            // spécifie la culture à utiliser pour le reste (entre autres la console)
            if (culture != null && culture.Name != "")
                CultureInfo.CurrentCulture = culture;
            else
                // la culture courante de Windows, dans sa version par défaut (hors customisations)
                CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(CultureInfo.CurrentCulture.Name);
        }

        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            SetCulture();

          //  Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();

        //    Context.SeedData();
            ClearContext();//efface le context -> repart d'un context vierge 

            Register<User>(this, Messages.MSG_LOGIN, user => {
                Login(user);
                if (CurrentUser is Manager) {
                    NavigateTo<ManagerViewModel, User, BankContext>();
                } else {
                    NavigateTo<MainViewModel, User, BankContext>();
                }

            });
            Register(this, Messages.MSG_LOGOUT, () => {
                Logout();
                NavigateTo<LoginViewModel, User, BankContext>();
            });

        }

        protected override void OnRefreshData() {

            if (CurrentUser?.Email != null)
                CurrentUser = User.GetByEmail(CurrentUser.Email);
        }
    }
}
