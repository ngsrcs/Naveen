using System;
using System.IO;
using DataLogicBAL.CMS.Exceptions;
using Newtonsoft.Json.Linq;
using static DataLogicBAL.CMS.Exceptions.ExceptionManager;

namespace DataLogicBAL.CMS.Utils
{
    public class SettingsManager<Utilities> : ISettingsManager<Utils.Utilities> 
    {
        JObject AppSettings;

        public SettingsManager()
        {
            // Read AppSettings File
            try
            {
                AppSettings = JObject.Parse(File.ReadAllText(Utils.Utilities.AppSettingsFile));
            }
            catch(Exception ex)
            {
                ex.GetBaseException();
            }        
        }

        public Utils.Utilities GetSettings()
        {
            // Get All Settings
            if (AppSettings.HasValues && (string)AppSettings["MongoConnection"]["ConnectionString"] != null && (string)AppSettings["MongoConnection"]["Database"] != null)
            {
                return new Utils.Utilities { ConnectionString = (string)AppSettings["MongoConnection"]["ConnectionString"], Database = (string)AppSettings["MongoConnection"]["Database"] };
            }
            else
                throw new InvalidParsingDataException(ExceptionsDetails.UtilsExceptions.EmptyAppSetingsFile);
        }
    }
}
