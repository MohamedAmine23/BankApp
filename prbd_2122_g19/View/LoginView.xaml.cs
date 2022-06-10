using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using PRBD_Framework;
namespace prbd_2122_g19.View {
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class LoginView : WindowBase {
        public LoginView() {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            Close();
        }
        private void txtEmail_GotFocus(object sender, RoutedEventArgs e) {
            txtEmail.SelectAll();
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e) {
            txtPassword.SelectAll();
        }
    }
}
