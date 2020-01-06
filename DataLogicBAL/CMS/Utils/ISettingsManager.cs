using DataAccessDAL.CRUD;

namespace DataLogicBAL.CMS.Utils
{
    public interface ISettingsManager<Utilities>
    {
        Utils.Utilities GetSettings();
    }
}