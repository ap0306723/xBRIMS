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
    /// AddBridgeInfoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddBridgeInfoWindow : MetroWindow
    {
        public AddBridgeInfoWindow()
        {
            InitializeComponent();

            this.Loaded += ((s, e) =>
            {
                AppData.Instance.ShowMarkLayer(true);
                var vm = DataContext as AddBridgeInfoViewModel;
                vm.BridgeInfo = new Models.BridgeInfo();

            });
            this.Closing += ((s, e) =>
            {
                AppData.Instance.ShowMarkLayer(false);
            });
        }
    }
}
