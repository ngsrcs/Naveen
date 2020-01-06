using System.Windows;
using DataLogicBAL.CMS.Exceptions;

namespace NaveenWPFApp.Utils.Logger
{
    public class LoggerManager
    {
        public MessageBoxResult DeleteEntryDialogBox()
        {
            return MessageBox.Show(ExceptionsDetails.LoggerDialogMessages.DeleteDialogText, ExceptionsDetails.LoggerDialogMessages.DeleteDialogHeader, 
                MessageBoxButton.YesNo, MessageBoxImage.Question);           
        }

        public void AddNewEntryDialogBox(string message)
        {
            MessageBox.Show(message, ExceptionsDetails.LoggerDialogMessages.WrongTextInputHeader, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void SearchEntryDialogBox(string message)
        {
            MessageBox.Show(message, ExceptionsDetails.LoggerDialogMessages.SearchDialogHeader, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void UpdateDialogBox(string message)
        {
            MessageBox.Show(message, ExceptionsDetails.LoggerDialogMessages.WrongTextInputHeader, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
