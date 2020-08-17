namespace AppWorldAgent.Infrastructure.Services.Dialog
{
    using Acr.UserDialogs;
    using AppWorldAgent.Infrastructure.Models.Enum;
    using System;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class DialogService : IDialogService
    {
        public Task ShowAlertAsync(string message, string title, string okText)
        {
            return UserDialogs.Instance.AlertAsync(message, title, okText);
        }

        public Task ShowConfirm(string message, string title, string okText, string cancelText)
        {
            return UserDialogs.Instance.ConfirmAsync(message, title, okText, cancelText);
        }

        public Task ShowDatePromptAsync(string title)
        {
            return UserDialogs.Instance.DatePromptAsync(title, DateTime.Now);
        }

        public void ShowToast(string message, ToastConfigEnum toastConfigEnum)
        {
            Color color, background;
            switch (toastConfigEnum)
            {
                case ToastConfigEnum.Success:
                    color = Color.FromHex("#ffffff");
                    background = Color.FromHex("#4cae4c");
                    break;
                case ToastConfigEnum.Error:
                    color = Color.FromHex("#ffffff");
                    background = Color.FromHex("#d43f3a");
                    break;
                case ToastConfigEnum.Warning:
                    color = Color.FromHex("#ffffff");
                    background = Color.FromHex("#eea236");
                    break;
                case ToastConfigEnum.Info:
                    color = Color.FromHex("#ffffff");
                    background = Color.FromHex("#269abc");
                    break;
                default:
                    color = Color.White;
                    background = Color.FromRgba(0, 0, 0, .6);
                    break;
            }
            ToastConfig toastConfig = new ToastConfig(message)
            {
                MessageTextColor = color,
                BackgroundColor = background,
                Position = ToastPosition.Top
            };
            UserDialogs.Instance.Toast(toastConfig);
        }

        public void ShowProgress(string title, string cancelText)
        {
            UserDialogs.Instance.Progress(title, null, cancelText);
        }

        public void ShowLoading(string message)
        {
            UserDialogs.Instance.ShowLoading(message);
        }

        public void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
        }
    }
}
