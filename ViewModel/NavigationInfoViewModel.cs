using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using xBRIMS.Models;
using xBRIMS.Windows;

namespace xBRIMS.ViewModel
{
    public class NavigationInfoViewModel : ViewModelBase
    {
        public NavigationInfoViewModel()
        {
            navigationInfos = new NavigationInfoProvider().Select();
        }

        private List<NavigationInfo> navigationInfos = new List<NavigationInfo>();

        public List<NavigationInfo> NavigationInfos
        {
            get
            {
                return navigationInfos;
            }
            set
            {
                navigationInfos = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand OpenAddNavigationInfoWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var window = new AddNavigationInfoWindow();
                    window.ShowDialog();
                    //刷新数据
                    NavigationInfos = new NavigationInfoProvider().Select();
                });
            }
        }

        public string DamName { get; set; }
        public string ChnName { get; set; }
        public string LockNavStatus { get; set; }
        public RelayCommand QuireNavigationInfoCommand
        {
            get
            {
                return new RelayCommand(() =>
                {

                    //MessageBoxResult result = MessageBox.Show($"{LocArea}+{ChnDeptBridgeName}+{ChnName}+{BridgeStatus}+{CurrLevelReq}+{PlanLevelReq}", "确认", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    List<NavigationInfo> allRecords = new NavigationInfoProvider().Select();
                    var queryResult = allRecords.Where(navigationInfo =>
                        (string.IsNullOrEmpty(DamName) || navigationInfo.DamName.Contains(DamName))
                     && (string.IsNullOrEmpty(ChnName) || navigationInfo.ChnName.Contains(ChnName))
                     && (string.IsNullOrEmpty(LockNavStatus) || navigationInfo.LockNavStatus.Contains(LockNavStatus))
                     ).ToList();

                    NavigationInfos = queryResult;
                });
            }
        }




        public RelayCommand<object> DeleteNavigationInfoCommand
        {
            get
            {
                return new RelayCommand<object>((arg) =>
                {
                    if (!(arg is NavigationInfo model)) return;

                    // 弹出确认对话框
                    MessageBoxResult result = MessageBox.Show($"确认删除航运枢纽大坝和通航建筑物信息: {model.DamName}?", "确认删除", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        var navigationInfos = new NavigationInfoProvider().Select().FindAll(t => t.NavigationID == model.NavigationID);
                        if (navigationInfos != null && navigationInfos.Count > 1)
                        {
                            MessageBox.Show("航运枢纽大坝和通航建筑物信息有误！");
                            return;
                        }

                        var count = new NavigationInfoProvider().Delete(model);
                        if (count > 0)
                        {
                            MessageBox.Show("删除成功！");
                            // 刷新数据
                            NavigationInfos = new NavigationInfoProvider().Select();
                        }
                    }
                });
            }
        }

        public RelayCommand<NavigationInfo> OpenViewNavigationInfoWindowCommand
        {
            get
            {
                return new RelayCommand<NavigationInfo>((navigationInfo) =>
                {
                    var window = new ViewNavigationInfoWindow(navigationInfo);
                    window.ShowDialog();
                });
            }
        }


    }
}
