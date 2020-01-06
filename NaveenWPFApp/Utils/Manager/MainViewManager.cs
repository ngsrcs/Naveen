using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using DataAccessDAL.CRUD;
using DataLogicBAL.BusinessLogic.Manager;
using DataLogicBAL.CMS.Exceptions;
using DataLogicBAL.CMS.Main;
using DataLogicBAL.CMS.Utils;
using NaveenWPFApp.DataAccessDAL.DTO.Models;
using NaveenWPFApp.DataLogicBAL.CMS.Main;
using NaveenWPFApp.Utils.Logger;

namespace NaveenWPFApp.Utils.Manager
{
    internal class MainViewManager : IMainViewManager
    {
        private GridView TableGridView;
        private IPersonManager _personManager;
        private IPersonRepository _personRepository;
        private ISettingsManager<Utilities> _settingsManager;
        private LoggerManager _logger;

        public MainViewManager()
        {
            TableGridView = new GridView();
            _logger = new LoggerManager();

            // [DI] Managers & Reposiotry
            _settingsManager = new SettingsManager<Utilities>();
            _personRepository = new PersonRepository(_settingsManager);
            _personManager = new PersonManager(_personRepository);
        }

        private void AddGridColumn(string header, string bindingname)
        {
            TableGridView.Columns.Add(new GridViewColumn
            {
                Header = header,
                DisplayMemberBinding = new Binding(bindingname)
            });
        }

        // Render Table
        public ListView RenderTable(ListView table)
        {
            if (TableGridView != null)
            {
                // Add Columns to table          
                foreach (var headers in Elements.Shared.MainView.TableHeaders)
                {
                    AddGridColumn(headers.Value, headers.Key);
                }
                
                // Init Table Display
                table.View = TableGridView;

                return table;
            }        
            else
               throw new Exception.RenderExceptions(ExceptionsDetails.RenderExceptions.FaildInitTable);
        }

        public ListView PopulateTable(ListView table)
        {
            // Populate Table List
            if (_personManager.GetAllPersons() != null)
            {
                foreach (Person p in _personManager.GetAllPersons().Result)
                {
                    table.Items.Add(p);
                }
            }             
            else
                table.Items.Add(new Person());

            return table;
        }

        // Set TextBox Data
        public void SetTextBoxData(TextBox textBox, string value)
        {
            textBox.Text = value;
        }

        // Set Label Text
        public void SetLabelText(Label label, string value)
        {           
            label.Content = value;
        }

        // Set Styles
        public void SetStyles(Window mainWindow)
        {
            mainWindow.FontFamily = new FontFamily(Styles.Shared.MainView.MainFontFamily);
        }

        // Search Event
        public Person Search_ClickEvent(string search_criteria)
        {
            Person personResult = null;

            // Multi Search by Name & Country
            if (search_criteria.Contains(","))
            {
                return _personManager.GetPerson(search_criteria, $"{(int)PersonRepository.SearchOptions.Name} {(int)PersonRepository.SearchOptions.Country}").Result;
            }
            // Search by Name
            else if (!(search_criteria.Contains(",")))
            {
                personResult = _personManager.GetPerson(search_criteria, $"{(int)PersonRepository.SearchOptions.Name}").Result;
            }
            // Search by Country
            else if(personResult == null)
            {
                personResult = _personManager.GetPerson(search_criteria, $"{(int)PersonRepository.SearchOptions.Country}").Result;
                if(personResult == null)
                {
                    _logger.SearchEntryDialogBox(ExceptionsDetails.LoggerDialogMessages.SearchDialogText);                    
                }              
            }

            return personResult;
        }

        // Add New Person Event
        public void Add_ClickEvent(string fullname, string age, string country)
        { 
            int age_result = 0;
            try
            {
                Int32.TryParse(age, out age_result);
            }
            catch (System.Exception ex)
            {
                _logger.AddNewEntryDialogBox(ExceptionsDetails.FieldInputException.AgeField);
            }

            if (!Regex.IsMatch(fullname, @"^[a-zA-Z'./s]{1,40}$"))
            {
                _logger.AddNewEntryDialogBox(ExceptionsDetails.FieldInputException.NameField);
            }
            if (!Regex.IsMatch(country, @"^[a-zA-Z'./s]{1,40}$"))
            {
                _logger.AddNewEntryDialogBox(ExceptionsDetails.FieldInputException.CountryField);
            }

            //Get Data from Fields
            Person personFromField = new Person() { FullName = fullname, Age = age_result, Country = country };

            if (personFromField.FullName == String.Empty && (personFromField.Age < 0 || personFromField.Age >= 140) && personFromField.Country == String.Empty)
            {
                _logger.AddNewEntryDialogBox(ExceptionsDetails.FieldInputException.NotingToUpdate);
            }

            _personManager.AddPerson(new Person());
        }

        // Delete Person Event
        public bool Delete_ClickEvent(Person person)
        {
            if (_logger.DeleteEntryDialogBox() == MessageBoxResult.Yes)
            {
                return _personManager.RemovePerson(person).Result;
            }

            return false;
        }

        // Update Person Event
        public bool Update_ClickEvent(Person person)
        {
            return _personManager.UpdatePerson(person).Result;  
        }
    }
}
