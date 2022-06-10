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
namespace prbd_2122_g19.View {
    /// <summary>
    /// Logique d'interaction pour AccountCardView.xaml
    /// </summary>
    public partial class AccountCardView : UserControlBase {
        
        public AccountCardView() {
            InitializeComponent();
        }
        public object MyCustomDataContext {
            get { return (object)GetValue(MyCustomDataContextProperty); }
            set { SetValue(MyCustomDataContextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyDataContext.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyCustomDataContextProperty =
            DependencyProperty.Register(nameof(MyCustomDataContext), typeof(object), typeof(AccountCardView), new PropertyMetadata(null));
    }
}
