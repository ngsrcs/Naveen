namespace DataLogicBAL.CMS.Exceptions
{
    public static class ExceptionsDetails
    {
        public static class RenderExceptions
        {
            public static string FaildInitTable = "[Exception] Faild to initialize the table grid !";
        }

        public static class UtilsExceptions
        {
            public static string FaildInitMainManager = "[Exception] Failed to initialize MainManager !";
            public static string EmptyAppSetingsFile = "[Exception] Empty App Setings File !";
        }

        public static class ConnectionExceptions
        {
            public static string FailedConnectingToDB = "[Exception] Failed Connecting to DB !";

            public static class CrudOperations
            {
                public static string FaildGetAllPersons = "[Exception] Faild getting all data !";
                public static string FaildAddPerson = "[Exception] Faild to add a new persons to the system !";
                public static string FaildDeletePerson = "[Exception] Faild to delete the persons from the system !";
                public static string FaildGetPerson = "[Exception] Faild to retrive the person informatons !";
                public static string FaildUpdatePerson = "[Exception] Faild to update the person informatons !";
                public static string WrongSearchCriteria = "[Exception] Wrong Search Criteria Variable !";
            }
        }

        public static class FieldInputException
        {
            public static string AgeField = "[Exception] Wrong data format for age !";
            public static string NameField = "[Exception] Wrong data format for name !";
            public static string CountryField = "[Exception] Wrong data format for country !";
            public static string NotingToUpdate = "[Exception] Fields Empty, nothing to update !";
        }

        public static class LoggerDialogMessages
        {
            public static string DeleteDialogText = "Do you want to delete the entry ?";
            public static string DeleteDialogHeader = "Confirmation";
            public static string WrongTextInputText = "Wrong data format !";
            public static string WrongTextInputHeader = "Warning Information";
            public static string SearchDialogText = "No entry matched the criteria searched !";
            public static string SearchDialogHeader = "Search Result Information";
            public static string NothingToDelete = "No Data has been selected !";
        }
    }
}
