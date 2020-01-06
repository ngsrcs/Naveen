using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLogicBAL.CMS.Exceptions;
using DataLogicBAL.CMS.Utils;
using NaveenWPFApp.DataAccessDAL.DTO.Models;
using NaveenWPFApp.DataLogicBAL.CMS.Main;
using MongoDB.Bson;
using MongoDB.Driver;
using static DataLogicBAL.CMS.Exceptions.ExceptionManager;

namespace DataAccessDAL.CRUD
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMongoDBManager _manager = null;

        public enum SearchOptions
        {
            ID = 0,
            Name = 1,
            Age = 2,
            Country = 3
        }     

        public PersonRepository(ISettingsManager<Utilities> settings)
        {
            // [DI] DB Manager Settings
            _manager = new MongoDBManager(settings);
        }

        public async Task AddPersonAsync(Person person)
        {
            try
            {
                await _manager.PersonsData.InsertOneAsync(person);
            }
            catch (Exception ex)
            {
                throw new FailedQueryingDataException(ExceptionsDetails.ConnectionExceptions.CrudOperations.FaildAddPerson, ex);
            }
        }

        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            try
            {
                return await _manager.PersonsData.Find(p => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new FailedQueryingDataException(ExceptionsDetails.ConnectionExceptions.CrudOperations.FaildGetAllPersons, ex);
            }
        }

        public async Task<Person> GetPersonAsync(string search_criteria, string search_option)
        {
            FilterDefinition<Person> filter = null;

            //Search by ID
            if (search_option == "0")
            {
                filter = Builders<Person>.Filter.Eq(Elements.Shared.TableHeaderId, search_criteria);

            }
            //Search by Name
            else if (search_option == "1")        
            {
                filter = Builders<Person>.Filter.Eq(Elements.Shared.MainView.TableHeaders.ElementAt(0).Key, search_criteria);
            }
            //Search by Age
            else if (search_option == "2")
            {
                filter = Builders<Person>.Filter.Eq(Elements.Shared.MainView.TableHeaders.ElementAt(1).Key, search_criteria);
            }
            //Search by Country
            else if (search_option == "3")
            {
                filter = Builders<Person>.Filter.Eq(Elements.Shared.MainView.TableHeaders.ElementAt(2).Key, search_criteria);
            }
            //Search by Name & Country
            else if (search_option == "13")
            {

                IEnumerable<Person> filterByNameAndCountry = await _manager.PersonsData.Find(x => x.FullName == search_criteria.Substring(0, search_criteria.IndexOf(","))
                    || x.Country == search_criteria.Substring(search_criteria.IndexOf(","), search_criteria.Length) 
                    || x.Country == search_criteria.Substring(0, search_criteria.IndexOf(",")) 
                    || x.FullName == search_criteria.Substring(search_criteria.IndexOf(","), search_criteria.Length)).ToListAsync();

                filter = Builders<Person>.Filter.Nin(x => x, filterByNameAndCountry.Select(f => f));
            }

            if (filter == null)
                throw new FailedQueryingDataException(ExceptionsDetails.ConnectionExceptions.CrudOperations.WrongSearchCriteria);
            try
            {
                return await _manager.PersonsData.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new FailedQueryingDataException(ExceptionsDetails.ConnectionExceptions.CrudOperations.FaildGetPerson, ex);
            }
        }

        public async Task<bool> RemoveAllPersonsAsync()
        {
            try
            {
                DeleteResult actionResult = await _manager.PersonsData.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw new FailedQueryingDataException(ExceptionsDetails.ConnectionExceptions.CrudOperations.FaildDeletePerson, ex);
            }
        }

        public async Task<bool> RemovePersonAsync(Person person)
        {
            try
            {
                DeleteResult actionResult = await _manager.PersonsData.DeleteOneAsync(Builders<Person>.Filter.Eq(Elements.Shared.TableHeaderId, person.Id));

                return actionResult.IsAcknowledged && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw new FailedQueryingDataException(ExceptionsDetails.ConnectionExceptions.CrudOperations.FaildDeletePerson, ex);
            }
        }

        public async Task<bool> UpdatePersonAsync(Person person)
        {
            try
            {
                ReplaceOneResult actionResult = await _manager.PersonsData.ReplaceOneAsync(n => n.Id.Equals(person.Id), person, new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                throw new FailedQueryingDataException(ExceptionsDetails.ConnectionExceptions.CrudOperations.FaildUpdatePerson, ex);
            }
        }
    }

 
}
