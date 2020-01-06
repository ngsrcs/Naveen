using System.Windows;
using System.Reflection;
using log4net;
using NaveenWPFApp.DataAccessDAL.DTO.Models;
using NaveenWPFApp.Utils.Manager;
using NaveenWPFApp.Utils.Exception;
using DataLogicBAL.CMS.Exceptions;
using NaveenWPFApp.DataLogicBAL.CMS.Main;
using NaveenWPFApp.Utils.Logger;

namespace NaveenWPFApp.Views
{
    public partial class MainWindow : Window
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private IMainViewManager MainManager;
        private Person person;
        private LoggerManager _logger;

        public void Init()
        {           
            InitializeComponent();
            MainManager = new MainViewManager();
            //Init Events
            Closing += MainView_Closing;
            Search_Button.Click += Search_ClickEvent;
            Add_Button.Click += Add_ClickEvent;
            Delete_Button.Click += Delete_ClickEvent;
            Update_Button.Click += Update_ClickEvent;
            DisplayListView.MouseDoubleClick += TableRow_ClickEvent;

            person = new Person();
            _logger = new LoggerManager();
        }

        public MainWindow()
        {
            // Initialize
            Init();

            // Mangers Check
            if (MainManager == null) throw new RenderExceptions(ExceptionsDetails.UtilsExceptions.FaildInitMainManager);

            #region Display Main View

            // Display Main View
            DisplayMainView();

            #endregion

            // Render Table  
            DisplayListView.View = MainManager.RenderTable(DisplayListView).View;

            //Populate Table
            //DisplayListView = MainManager.PopulateTable(DisplayListView);
        }

        private void DisplayMainView()
        {
            //Set Styles
            MainManager.SetStyles(MainWindowRenderer);

            ////Set Search Field Text 
            MainManager.SetTextBoxData(SearchField, Elements.Shared.MainView.TextBoxSearchField);

            ////Set Label Text
            MainManager.SetLabelText(FullNameLabel, Elements.Shared.MainView.LabelFullName);
            MainManager.SetLabelText(AgeLabel, Elements.Shared.MainView.LabelAge);
            MainManager.SetLabelText(CountryLabel, Elements.Shared.MainView.LabelCountry);

            ////Set TextBox Data
            MainManager.SetTextBoxData(FullNameTextBox, person.FullName);
            MainManager.SetTextBoxData(AgeTextBox, person.Age.ToString());
            MainManager.SetTextBoxData(CountryTextBox, person.Country);
        }

        // Add New Person Event
        private void Add_ClickEvent(object sender, RoutedEventArgs e)
        {
            MainManager.Add_ClickEvent(FullNameTextBox.Text, AgeTextBox.Text, CountryTextBox.Text);
        }

        // Search Person Event
        private void Search_ClickEvent(object sender, RoutedEventArgs e)
        {
            if(SearchField.Text != string.Empty)
            {
                // Display the search result
                Person searchResult = MainManager.Search_ClickEvent(SearchField.Text);
                // Clear List
                DisplayListView.Items.Clear();
                // Populate with search result
                DisplayListView.Items.Add(searchResult);
            }
            else
            {
                // Refresh Table Grid with db data
                DisplayListView.View = MainManager.PopulateTable(DisplayListView).View;
            }
        }

        // Table Event
        private void TableRow_ClickEvent(object sender, RoutedEventArgs e)
        {         
           if (DisplayListView.SelectedItems.Count == 0) return;
           {
                person = new Person();
                person = (Person)DisplayListView.SelectedItems[0];
            }
            
            //Set TextBox Data
            MainManager.SetTextBoxData(FullNameTextBox, person.FullName);
            MainManager.SetTextBoxData(AgeTextBox, person.Age.ToString());
            MainManager.SetTextBoxData(CountryTextBox, person.Country);
        }

        private void Delete_ClickEvent(object sender, RoutedEventArgs e)
        {
            if (DisplayListView.SelectedItems.Count == 0)
                _logger.UpdateDialogBox(ExceptionsDetails.LoggerDialogMessages.NothingToDelete);
            MainManager.Delete_ClickEvent(person);
        }

        private void Update_ClickEvent(object sender, RoutedEventArgs e)
        {
            if (DisplayListView.SelectedItems.Count == 0)
                _logger.UpdateDialogBox(ExceptionsDetails.FieldInputException.NotingToUpdate);
            MainManager.Update_ClickEvent(person);
        }
      
        private void MainView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
             Log.Info("Closing App");
        }
    }
}
