using System.Windows;
using System.Windows.Controls;
using NaveenWPFApp.DataAccessDAL.DTO.Models;

namespace NaveenWPFApp.Utils.Manager
{
    internal interface IMainViewManager
    {
        ListView RenderTable(ListView table);
        void SetTextBoxData(TextBox textBox, string value);
        void SetLabelText(Label label, string value);
        void SetStyles(Window mainWindow);

        void Add_ClickEvent(string fullname, string age, string country);
        Person Search_ClickEvent(string search_criteria);
        ListView PopulateTable(ListView table);
        bool Delete_ClickEvent(Person person);
        bool Update_ClickEvent(Person person);
    }
}
