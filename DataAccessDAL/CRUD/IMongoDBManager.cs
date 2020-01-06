using NaveenWPFApp.DataAccessDAL.DTO.Models;
using MongoDB.Driver;

namespace DataAccessDAL.CRUD
{
    public interface IMongoDBManager
    {
        IMongoCollection<Person> PersonsData { get; }
    }
}
