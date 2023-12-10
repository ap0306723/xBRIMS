using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using xBRIMS.Models;

namespace xBRIMS.ViewModel
{
    public class ViewBridgeInfoViewModel : ViewModelBase
    {
        private BridgeInfo bridgeInfo = new BridgeInfo();

        public BridgeInfo BridgeInfo
        {
            get { return bridgeInfo; }
            set { bridgeInfo = value; RaisePropertyChanged(); }

        }

        public ViewBridgeInfoViewModel() {
            MessageBoxResult result = MessageBox.Show($"{BridgePhoto01}", "确认", MessageBoxButton.YesNo, MessageBoxImage.Warning);



        }


        public RelayCommand CloseWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    // 在此处处理窗口关闭逻辑
                    CloseWindow();
                });
            }
        }

        private void CloseWindow()
        {
            // 在此处处理窗口关闭逻辑
            // 例如，关闭窗口的代码
            Application.Current.MainWindow.Close();
        }


    }
}
