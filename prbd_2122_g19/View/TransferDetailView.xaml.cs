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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PRBD_Framework;
using prbd_2122_g19.model;
namespace prbd_2122_g19.View {
    /// <summary>
    /// Logique d'interaction pour TransferDetailView.xaml
    /// </summary>
    public partial class TransferDetailView : UserControlBase {
        public TransferDetailView(Representative representative) {
            InitializeComponent();
            vm.Init(representative);
            
        }
        private void txtCommunication_GotFocus(object sender, RoutedEventArgs e) {
            txtCommunication.SelectAll();
        }
        private void txtAmount_GotFocus(object sender, RoutedEventArgs e) {
            txtAmount.SelectAll();
        }
        private void txtToAccount_GotFocus(object sender, RoutedEventArgs e) {
            txtToAccount.SelectAll();
        }
    }
}
