using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using xBRIMS.Models;

namespace xBRIMS.ViewModel
{
    public class AddNavigationInfoViewModel : ViewModelBase
    {
        public AppData AppData { get; set; } = AppData.Instance;

        private NavigationInfo navigationInfo = new NavigationInfo();

        public NavigationInfo NavigationInfo
        {
            get { return navigationInfo; }
            set { navigationInfo = value; RaisePropertyChanged(); }

        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        public RelayCommand<Window> CloseCommand
        {
            get
            {
                return new RelayCommand<Window>((arg) =>
                {
                    if (arg == null) return;
                    arg.Close();
                });
            }
        }

        /// <summary>
        /// 添加新的航运枢纽大坝和通航建筑物信息
        /// </summary>
        public RelayCommand<Window> AddNavigationInfoCommand
        {
            get
            {
                return new RelayCommand<Window>((arg) =>
                {
                    if (string.IsNullOrEmpty(navigationInfo.DamNavStrucType)) return;
                    if (string.IsNullOrEmpty(navigationInfo.DamName)) return;
                    var count = new NavigationInfoProvider().Insert(navigationInfo);
                    if (count == 0)
                    {
                        MessageBox.Show("添加失败!");
                    }
                    else
                    {
                        MessageBox.Show("添加成功!");
                        arg.Close();
                    }
                });
            }
        }

     
    }
}
