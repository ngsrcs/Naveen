using System.IO;

namespace DataLogicBAL.CMS.Utils
{
    public class Utilities
    {
        public static string AppSettingsFile = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf("NaveenWPFApp\\")) + "DataLogicBAL\\CMS\\Utils\\AppSettings.json";
       
        internal string ConnectionString;
        internal string Database;
    }
}
