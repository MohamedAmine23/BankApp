using PRBD_Framework;
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

namespace prbd_2122_g19.View {
    /// <summary>
    /// Logique d'interaction pour ManagerView.xaml
    /// </summary>
    public partial class ManagerView : WindowBase {
        public ManagerView() {
            InitializeComponent();
        }
        private void MenuLogout_Click(object sender, System.Windows.RoutedEventArgs e) {
            NotifyColleagues(App.Messages.MSG_LOGOUT);
        }

        private void WindowBase_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Q && Keyboard.IsKeyDown(Key.LeftCtrl))
                Close();
        }
    }
}
