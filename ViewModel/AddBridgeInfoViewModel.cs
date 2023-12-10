using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using xBRIMS.Models;

namespace xBRIMS.ViewModel
{
    public class AddBridgeInfoViewModel : ViewModelBase
    {
        public AppData AppData { get; set; } = AppData.Instance;

        private BridgeInfo bridgeInfo = new BridgeInfo();

        public BridgeInfo BridgeInfo
        { 
            get { return bridgeInfo; }
            set { bridgeInfo = value; RaisePropertyChanged(); }
        
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
        /// 添加新的桥梁信息
        /// </summary>
        public RelayCommand<Window> AddBridgeInfoCommand
        {
            get
            {
                return new RelayCommand<Window>((arg) =>
                {
                    if (string.IsNullOrEmpty(bridgeInfo.ChnDeptBridgeName)) return;
                    if (string.IsNullOrEmpty(bridgeInfo.ChnAfairsCenter)) return;
                    var count = new BridgeInfoProvider().Insert(bridgeInfo);
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
