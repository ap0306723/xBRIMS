/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:xBRIMS"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using xBRIMS.Windows;

namespace xBRIMS.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<BridgeInfoViewModel>();
            SimpleIoc.Default.Register<NavigationInfoViewModel>();
            SimpleIoc.Default.Register<ReportViewModel>();
            SimpleIoc.Default.Register<AddBridgeInfoViewModel>();
            SimpleIoc.Default.Register<ViewBridgeInfoViewModel>();
            SimpleIoc.Default.Register<AddNavigationInfoViewModel>();
            SimpleIoc.Default.Register<ViewNavigationInfoViewModel>();
        }

        public MainViewModel Main

        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public BridgeInfoViewModel BridgeInfo
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BridgeInfoViewModel>();
            }
        }

        public NavigationInfoViewModel NavigationInfo
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NavigationInfoViewModel>();
            }
        }

        public ReportViewModel Report
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ReportViewModel>();
            }
        }

        public AddBridgeInfoViewModel AddBridgeInfo
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddBridgeInfoViewModel>();
            }
        }
        
        public ViewBridgeInfoViewModel ViewBridgeInfo
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ViewBridgeInfoViewModel>();
            }
        }

        public AddNavigationInfoViewModel AddNavigationInfo
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddNavigationInfoViewModel>();
            }
        }

        public ViewNavigationInfoViewModel ViewNavigationInfo
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ViewNavigationInfoViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}