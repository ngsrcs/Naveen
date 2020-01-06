using MongoDB.Driver;
using NaveenWPFApp.DataAccessDAL.DTO.Models;
using DataLogicBAL.CMS.Utils;
using static DataLogicBAL.CMS.Exceptions.ExceptionManager;
using DataLogicBAL.CMS.Exceptions;
using System;

namespace DataAccessDAL.CRUD
{
    public class MongoDBManager : IMongoDBManager
    {
        private readonly IMongoDatabase _database = null;

        public MongoDBManager(ISettingsManager<Utilities> settings)
        {
            try
            {
                Utilities utilities = settings.GetSettings();

                var client = new MongoClient(utilities.ConnectionString);
                if (client != null)
                    _database = client.GetDatabase(utilities.Database);
                else
                    throw new FailedConnectingToDBException(ExceptionsDetails.ConnectionExceptions.FailedConnectingToDB);
            }
            catch(Exception ex)
            {
                throw new FailedConnectingToDBException(ExceptionsDetails.ConnectionExceptions.FailedConnectingToDB, ex);
            }                    
        }

        public IMongoCollection<Person> PersonsData => _database.GetCollection<Person>("PersonData");
    }
}

