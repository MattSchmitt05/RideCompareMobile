using RideCompare.Services.Dialog;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideCompare.Tests.AcceptanceTests.TestDoubles.Services.Dialog
{
    [ExcludeFromCodeCoverage]
    internal sealed class DialogServiceSpy : DialogServiceBase
    {
        protected override void HideLoadingCore()
        {
            throw new NotImplementedException();
        }

        protected override Task ShowAlertAsyncCore(string message, string title, string cancelButton)
        {
            throw new NotImplementedException();
        }

        protected override void ShowLoadingCore()
        {
            throw new NotImplementedException();
        }
    }
}
