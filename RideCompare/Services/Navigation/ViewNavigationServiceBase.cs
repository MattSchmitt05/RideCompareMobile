using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RideCompare.Services.Navigation
{
    internal abstract class ViewNavigationServiceBase
    {
        public void NavigateTo(string pageName) => NavigateToCore(pageName);
        public void NavigateTo(string pageName, NavigationParameters navigationParameters) => NavigateToCore(pageName, navigationParameters);
        public async Task NavigateToRootPageAsync(NavigationParameters navigationParameters) => await NavigateToRootPageAsyncCore(navigationParameters);

        protected abstract void NavigateToCore(string pageName);
        protected abstract void NavigateToCore(string pageName, NavigationParameters navigationParameters);
        protected abstract Task NavigateToRootPageAsyncCore(NavigationParameters navigationParameters);
    }
}
