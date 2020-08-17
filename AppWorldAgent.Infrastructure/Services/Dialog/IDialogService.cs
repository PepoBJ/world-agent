namespace AppWorldAgent.Infrastructure.Services.Dialog
{
    using AppWorldAgent.Infrastructure.Models.Enum;
    using System.Threading.Tasks;

    public interface IDialogService
    {
        void HideLoading();
        Task ShowAlertAsync(string message, string title, string okText);
        Task ShowConfirm(string message, string title, string okText, string cancelText);
        Task ShowDatePromptAsync(string title);
        void ShowLoading(string message);
        void ShowProgress(string title, string cancelText);
        void ShowToast(string message, ToastConfigEnum toastConfigEnum);
    }
}
