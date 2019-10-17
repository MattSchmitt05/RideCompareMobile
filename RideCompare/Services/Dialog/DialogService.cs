using System.Threading.Tasks;
using Acr.UserDialogs;

namespace RideCompare.Services.Dialog
{
    internal sealed class DialogService : DialogServiceBase
    {
        protected override void ShowLoadingCore()
        {
            UserDialogs.Instance.ShowLoading();
            return;
        }

        protected override void HideLoadingCore()
        {
            UserDialogs.Instance.HideLoading();
            return;
        }

        protected override async Task ShowAlertAsyncCore(string message, string title, string cancelButton)
        {
            await UserDialogs.Instance.AlertAsync(message, title, cancelButton);
        }
    }
}
