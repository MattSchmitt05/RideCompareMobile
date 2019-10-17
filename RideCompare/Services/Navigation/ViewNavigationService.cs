using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RideCompare.Services.Navigation
{
    internal sealed class ViewNavigationService : ViewNavigationServiceBase
    {
        private static IViewNavigationService _navigationService;

        public ViewNavigationService(IViewNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        protected override void NavigateToCore(string pageName)
        {
            _navigationService.NavigateAsync(pageName);
        }

        protected override void NavigateToCore(string pageName, NavigationParameters navigationParameters)
        {
            _navigationService.NavigateAsync(pageName, navigationParameters);
        }

        protected override async Task NavigateToRootPageAsyncCore(NavigationParameters navigationParameters)
        {
            await _navigationService.GoBackToRootAsync(navigationParameters);
        }
    }

    internal interface IViewNavigationService : INavigationService
    {

    }
}
