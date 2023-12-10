using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;
using xBRIMS.Models;
using xBRIMS.View;

namespace xBRIMS.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public AppData AppData { get; private set; } = AppData.Instance;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        public RelayCommand<RadioButton> SelectViewCommand
        {
            get
            {
                return new RelayCommand<RadioButton>((arg) =>
                {
                    if (!(arg is RadioButton button)) return;
                    if (string.IsNullOrEmpty(button.Content.ToString())) return;
                    switch (button.Content.ToString())
                    {
                        case "桥梁信息": AppData.Instance.MainWindow.container.Content = new BridgeInfoView(); break;
                        case "建筑信息": AppData.Instance.MainWindow.container.Content = new NavigationInfoView(); break;
                        case "报表统计": AppData.Instance.MainWindow.container.Content = new ReportView(); break;
                        default:
                            break;
                    }
                });
            }
        }
    }
}