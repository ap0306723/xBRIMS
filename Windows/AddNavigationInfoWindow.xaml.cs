using MahApps.Metro.Controls;
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
using xBRIMS.ViewModel;

namespace xBRIMS.Windows
{
    /// <summary>
    /// AddNavigationInfoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddNavigationInfoWindow : MetroWindow
    {
        public AddNavigationInfoWindow()
        {
            InitializeComponent();

            this.Loaded += ((s, e) =>
            {
                AppData.Instance.ShowMarkLayer(true);
                var vm = DataContext as AddNavigationInfoViewModel;
                vm.NavigationInfo = new Models.NavigationInfo();

            });
            this.Closing += ((s, e) =>
            {
                AppData.Instance.ShowMarkLayer(false);
            });
        }
    }
}
