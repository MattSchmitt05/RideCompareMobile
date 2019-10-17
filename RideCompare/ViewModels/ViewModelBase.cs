using System.Collections.Generic;
using Prism.Mvvm;
using Prism.Navigation;
using RideCompare.Services.Dialog;
using RideCompare.Services.Navigation;
using RideCompare.Services.ServiceLocator;
using Xamarin.Forms;

namespace RideCompare.ViewModels
{
    internal abstract class ViewModelBase : BindableBase, INavigationAware
    {
        private static IViewNavigationService _navigationService;

        private static ServiceLocatorBase _serviceLocator;
        protected static ServiceLocatorBase ServiceLocator => _serviceLocator ?? (_serviceLocator = new ServiceLocator());

        private static ViewNavigationServiceBase _viewNavigationService;
        protected static ViewNavigationServiceBase ViewNavigationService => _viewNavigationService ?? (_viewNavigationService = ServiceLocator.CreateViewNavigationService(_navigationService));

        private static DialogServiceBase _dialogService;
        protected static DialogServiceBase DialogService => _dialogService ?? (_dialogService = ServiceLocator.CreateDialogService());

        public IReadOnlyList<Page> ModalStack => throw new System.NotImplementedException();
        public IReadOnlyList<Page> NavigationStack => throw new System.NotImplementedException();

        protected ViewModelBase(IViewNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }
    }
}
