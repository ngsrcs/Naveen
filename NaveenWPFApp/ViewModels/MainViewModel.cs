using NaveenWPFApp.DataLogicBAL.CMS.Main;
using MvvmDialogs;

namespace NaveenWPFApp.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        #region Parameters
        private readonly IDialogService DialogService;

        public string Title { get; set; } = Elements.Shared.MainView.TitleApp;

        #endregion

        #region Constructors
        public MainViewModel()
        {
            // DialogService is used to handle dialogs
            this.DialogService = new MvvmDialogs.DialogService();
        }

        #endregion

        #region Methods
        public void OnExitApp() => System.Windows.Application.Current.MainWindow.Close();

        #endregion

        #region Events

        #endregion
    }
}
