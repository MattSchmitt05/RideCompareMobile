using System.Collections.Generic;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace RideCompare.ViewModels
{
    internal abstract class ViewModelBase : BindableBase, INavigationAware
    {
        protected INavigationService NavigationService { get; private set; }

        public IReadOnlyList<Page> ModalStack => throw new System.NotImplementedException();
        public IReadOnlyList<Page> NavigationStack => throw new System.NotImplementedException();

        protected ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
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
