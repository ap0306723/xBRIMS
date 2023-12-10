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
using xBRIMS.Models;
using xBRIMS.ViewModel;

namespace xBRIMS.Windows
{
    /// <summary>
    /// ViewBridgeInfoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ViewBridgeInfoWindow : MetroWindow
    {
        public ViewBridgeInfoWindow(BridgeInfo bridgeInfo)
        {
            InitializeComponent();

            this.Loaded += ((s, e) =>
            {
                AppData.Instance.ShowMarkLayer(true);
                DataContext = bridgeInfo;


            });
            this.Closing += ((s, e) =>
            {
                AppData.Instance.ShowMarkLayer(false);
            });
        }
    }
}
