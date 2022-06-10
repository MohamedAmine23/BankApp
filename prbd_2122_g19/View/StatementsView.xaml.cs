using prbd_2122_g19.model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prbd_2122_g19.View {
    /// <summary>
    /// Logique d'interaction pour StatementsView.xaml
    /// </summary>
    public partial class StatementsView : UserControlBase {
        public StatementsView(Representative representative) {
            InitializeComponent();
            vm.Init(representative);
        }
    }
}
