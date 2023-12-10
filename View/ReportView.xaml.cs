using LiveCharts.Wpf;
using LiveCharts;
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
using xBRIMS.ViewModel;
using xBRIMS.Models;

namespace xBRIMS.View
{
    /// <summary>
    /// ReportView.xaml 的交互逻辑
    /// </summary>
    public partial class ReportView : UserControl
    {
        public ReportView()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                //获取桥梁信息
                var vm = DataContext as ReportViewModel;
                var bridgeInfoProvider = new BridgeInfoProvider();
                var bridgeInfos = bridgeInfoProvider.Select();

                vm.BridgeInfoLabels.Clear();
                vm.BridgeInfoChartValues.Clear();


                //显示桥梁的分组报表
                var bridgeCount = bridgeInfos.GroupBy(b => b.LocArea).Select(group => new { LocArea = group.Key, Count = group.Count() });
                foreach (var result in bridgeCount)
                {
                    vm.BridgeInfoLabels.Add(result.LocArea);
                    vm.BridgeInfoChartValues.Add(result.Count);
                }

                //获取通航建筑物信息
                var navigationInfoProvider = new NavigationInfoProvider();
                var navigationInfos = navigationInfoProvider.Select();

                vm.NavigationInfoLabels.Clear();
                vm.NavigationInfoChartValues.Clear();

                //显示通航建筑物的分组报表
                var NavigationCount = navigationInfos.GroupBy(b => b.DamNavStrucType).Select(group => new { DamNavStrucType = group.Key, Count = group.Count() });
                foreach (var result in NavigationCount)
                {
                    vm.NavigationInfoLabels.Add(result.DamNavStrucType);
                    vm.NavigationInfoChartValues.Add(result.Count);
                }



            };
        }

        private void CartesianChart_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
