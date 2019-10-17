using Prism.Navigation;
using RideCompare.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideCompare.Tests.AcceptanceTests.TestDoubles.Services.Navigation
{
    [ExcludeFromCodeCoverage]
    internal sealed class ViewNavigationServiceSpy : ViewNavigationServiceBase
    {
        protected override void NavigateToCore(string pageName)
        {
            throw new NotImplementedException();
        }

        protected override void NavigateToCore(string pageName, NavigationParameters navigationParameters)
        {
            throw new NotImplementedException();
        }

        protected override Task NavigateToRootPageAsyncCore(NavigationParameters navigationParameters)
        {
            throw new NotImplementedException();
        }
    }
}
