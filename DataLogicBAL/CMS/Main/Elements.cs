using System.Collections.Generic;

namespace NaveenWPFApp.DataLogicBAL.CMS.Main
{
    public static class Elements
    {
        public static class Shared
        {
            internal static string TableHeaderId = "Id";

            public static class MainView
            {               
                public static string TitleApp = "Naveen WPF App";
                public static string TextBoxSearchField = "Search by Name and/or Country";
                public static Dictionary<string, string> TableHeaders = new Dictionary<string, string>() { { "FullName", "Full Name" }, { "Age", "Age" }, { "Country", "Country" } };
                public static string LabelFullName = "Full Name";
                public static string LabelAge = "Age";
                public static string LabelCountry = "Country";
            }
        }
    }
}
