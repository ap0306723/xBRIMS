using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using xBRIMS.Models;
using xBRIMS.Windows;

namespace xBRIMS.ViewModel
{
    public class BridgeInfoViewModel : ViewModelBase
    {
        public BridgeInfoViewModel()
        {
            bridgeInfos = new BridgeInfoProvider().Select();
        }

        private List<BridgeInfo> bridgeInfos = new List<BridgeInfo>();

        public List<BridgeInfo> BridgeInfos
        {
            get
            {
                return bridgeInfos;
            }
            set
            {
                bridgeInfos = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand OpenAddBridgeInfoWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var window = new AddBridgeInfoWindow();
                    window.ShowDialog();
                    //刷新数据
                    BridgeInfos = new BridgeInfoProvider().Select();
                });
            }
        }

        public RelayCommand<BridgeInfo> OpenViewBridgeInfoWindowCommand
        {
            get
            {
                return new RelayCommand<BridgeInfo>((bridgeInfo) =>
                {
                    var window = new ViewBridgeInfoWindow(bridgeInfo);
                    window.ShowDialog();
                });
            }
        }

        // 查询符合条件的桥梁信息
        private string LocArea { get ; set; }

        private string _selectedLocArea;
        public string SelectedLocArea
        {
            get { return _selectedLocArea; }
            set
            {
                if (_selectedLocArea != value)
                {
                    _selectedLocArea = value;
                    RaisePropertyChanged(nameof(SelectedLocArea));
                }
            }
        }
        public string ChnDeptBridgeName { get; set; }
        public string ChnName { get; set; }
        public string BridgeStatus { get; set; }

        private string CurrLevelReq { get; set; }

        private string _selectedCurrLevelReq;
        public string SelectedCurrLevelReq
        {
            get { return _selectedCurrLevelReq; }
            set
            {
                if (_selectedCurrLevelReq != value)
                {
                    _selectedCurrLevelReq = value;
                    RaisePropertyChanged(nameof(SelectedCurrLevelReq));
                }
            }
        }
        private string PlanLevelReq { get; set; }

        private string _selectedPlanLevelReq;
        public string SelectedPlanLevelReq
        {
            get { return _selectedPlanLevelReq; }
            set
            {
                if (_selectedPlanLevelReq != value)
                {
                    _selectedPlanLevelReq = value;
                    RaisePropertyChanged(nameof(SelectedPlanLevelReq));
                }
            }
        }


        public RelayCommand QuireBridgeInfoCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    LocArea=this.SelectedLocArea;
                    CurrLevelReq = this.SelectedCurrLevelReq;
                    PlanLevelReq = this.SelectedPlanLevelReq;
                    //MessageBoxResult result = MessageBox.Show($"{LocArea}+{ChnDeptBridgeName}+{ChnName}+{BridgeStatus}+{CurrLevelReq}+{PlanLevelReq}", "确认", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    List<BridgeInfo> allRecords = new BridgeInfoProvider().Select();
                    var queryResult = allRecords.Where(bridgeInfo =>
                        (string.IsNullOrEmpty(LocArea) || bridgeInfo.LocArea.Contains(LocArea))
                     && (string.IsNullOrEmpty(ChnDeptBridgeName) || bridgeInfo.ChnDeptBridgeName.Contains(ChnDeptBridgeName))
                     && (string.IsNullOrEmpty(ChnName) || bridgeInfo.ChnDeptBridgeName.Contains(ChnName))
                     && (string.IsNullOrEmpty(BridgeStatus) || bridgeInfo.BridgeStatus.Contains(BridgeStatus))
                     && (string.IsNullOrEmpty(CurrLevelReq) || bridgeInfo.CurrLevelReq == CurrLevelReq)
                     && (string.IsNullOrEmpty(PlanLevelReq) || bridgeInfo.PlanLevelReq == PlanLevelReq)
                     ).ToList();

                    BridgeInfos = queryResult;
                });
            }
        }

        /// <summary>
        /// 删除桥梁信息命令
        /// </summary>
        public RelayCommand<object> DeleteBridgeInfoCommand
        {
            get
            {
                return new RelayCommand<object>((arg) =>
                {
                    if (!(arg is BridgeInfo model)) return;

                    // 弹出确认对话框
                    MessageBoxResult result = MessageBox.Show($"确认删除桥梁信息: {model.ChnDeptBridgeName}?", "确认删除", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        var bridgeinfos = new BridgeInfoProvider().Select().FindAll(t => t.BridgeID == model.BridgeID);
                        if (bridgeinfos != null && bridgeinfos.Count > 1)
                        {
                            MessageBox.Show("桥梁信息有误！");
                            return;
                        }

                        var count = new BridgeInfoProvider().Delete(model);
                        if (count > 0)
                        {
                            MessageBox.Show("删除成功！");
                            // 刷新数据
                            BridgeInfos = new BridgeInfoProvider().Select();
                        }
                    }
                });
            }
        }

    }
}
