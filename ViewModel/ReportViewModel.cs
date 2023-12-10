using GalaSoft.MvvmLight;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xBRIMS.ViewModel
{
    public class ReportViewModel : ViewModelBase
    {
        public ReportViewModel()
        {

        }

        private IChartValues bridgeInfoChartValues = new ChartValues<int>();

        /// <summary>
        /// 桥梁的value值
        /// </summary>
        public IChartValues BridgeInfoChartValues
        {
            get { return bridgeInfoChartValues; }
            set { bridgeInfoChartValues = value; RaisePropertyChanged(); }
        }

        private List<string> cargoLabels = new List<string>();


        private List<string> bridgeInfoLabels = new List<string>();
        /// <summary>
        /// 桥梁的X轴标签
        /// </summary>
        public List<string> BridgeInfoLabels
        {
            get { return bridgeInfoLabels; }
            set { bridgeInfoLabels = value; RaisePropertyChanged(); }
        }








        private IChartValues navigationInfoChartValues = new ChartValues<int>();

        /// <summary>
        /// 通航建筑物的value值
        /// </summary>
        public IChartValues NavigationInfoChartValues
        {
            get { return navigationInfoChartValues; }
            set { navigationInfoChartValues = value; RaisePropertyChanged(); }
        }


        private List<string> navigationInfoLabels = new List<string>();
        /// <summary>
        /// 通航建筑物的X轴标签
        /// </summary>
        public List<string> NavigationInfoLabels
        {
            get { return navigationInfoLabels; }
            set { navigationInfoLabels = value; RaisePropertyChanged(); }
        }










    }
}
