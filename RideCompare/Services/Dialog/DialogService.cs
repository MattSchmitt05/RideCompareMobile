using System.Threading.Tasks;
using Acr.UserDialogs;

namespace RideCompare.Services.Dialog
{
    internal static class DialogService
    {
        public static void ShowLoading()
        {
            UserDialogs.Instance.ShowLoading();
            return;
        }

        public static void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
            return;
        }

        public async static Task ShowAlert(string message)
        {
            await UserDialogs.Instance.AlertAsync(message, "Best Ride", "OK");
        }
    }
}
