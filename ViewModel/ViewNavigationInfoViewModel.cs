using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using xBRIMS.Models;

namespace xBRIMS.ViewModel
{
    public class ViewNavigationInfoViewModel : ViewModelBase
    {
        private NavigationInfo navigationInfo = new NavigationInfo();


        public NavigationInfo NavigationInfo
        {
            get { return navigationInfo; }
            set { navigationInfo = value; RaisePropertyChanged(); }

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
