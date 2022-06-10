using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using prbd_2122_g19.model;
using PRBD_Framework;
namespace prbd_2122_g19.View {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : WindowBase {
        public MainView() {
            InitializeComponent();
            Register<Representative>(App.Messages.MSG_NEW_TRANSFER,
            representative => DoDisplayTransfer(representative));
            Register<Representative>(App.Messages.MSG_DISPLAY_STATEMENTS,
            representative => DoDisplayStatements(representative));
            Register<Representative>(App.Messages.MSG_CLOSE_TAB, rep => DoCloseTab(rep));
        }
        
        private void DoDisplayTransfer( Representative representative ) {
            if (representative != null)
                OpenTab( "New Transfer" ,representative.InternalAccountIban, () => new TransferDetailView(representative));
        }
        private void DoDisplayStatements(Representative representative) {
            if (representative != null)
                OpenTab(representative.InternalAccountIban, representative.InternalAccount.Description, () => new StatementsView(representative));
        }

        private void OpenTab(string header, string tag, Func<UserControlBase> createView) {
            var tab = tabControl.FindByTag(tag);
            if (tab == null)
                tabControl.Add(createView(), header, tag);
            else
                tabControl.SetFocus(tab);
        }
        private void DoCloseTab(Representative rep) {
            var tab = tabControl.FindByTag(rep.InternalAccountIban);
            tabControl.Items.Remove(tab);
        }
        private void MenuLogout_Click(object sender, System.Windows.RoutedEventArgs e) {
            NotifyColleagues(App.Messages.MSG_LOGOUT);
        }

        private void WindowBase_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Q && Keyboard.IsKeyDown(Key.LeftCtrl))
                Close();
        }

        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);
            tabControl.Dispose();
        }
    }
}

