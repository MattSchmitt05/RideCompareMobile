using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RideCompare.Services.Dialog
{
    internal abstract class DialogServiceBase
    {
        public void ShowLoading() => ShowLoadingCore();
        public void HideLoading() => HideLoadingCore();
        public async Task ShowAlertAsync(string message, string title, string cancelButton) => await ShowAlertAsyncCore(message, title, cancelButton);

        protected abstract void ShowLoadingCore();
        protected abstract void HideLoadingCore();
        protected abstract Task ShowAlertAsyncCore(string message, string title, string cancelButton);
    }
}
