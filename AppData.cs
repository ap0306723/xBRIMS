using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xBRIMS.Models;


namespace xBRIMS
{
    public class AppData : ObservableObject
    {
        public AppData()
        {

        }

        public static AppData Instance = new Lazy<AppData>(() => new AppData()).Value;

        private string systemName = "广东省航道事务中心基础资料汇编 2.0";
        public string SystemName
        {
            get { return systemName; }
            set { systemName = value; RaisePropertyChanged(); }
        }

        public MainWindow MainWindow { get; set; } = null;


        /// <summary>
        /// 显示或隐藏遮罩层
        /// </summary>
        /// <param name="isMark"></param>
        public void ShowMarkLayer(bool isMark)
        {
            if (MainWindow == null) return;
            MainWindow.markLayer.Visibility = isMark ? System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
        }
    }
}
