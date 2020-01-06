using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessDAL.CRUD;
using NaveenWPFApp.DataAccessDAL.DTO.Models;

namespace DataLogicBAL.BusinessLogic.Manager
{
    public class PersonManager : IPersonManager
    {
        private IPersonRepository _repository;

        public PersonManager(IPersonRepository repository)
        {
            // [DI] Repository
            _repository = repository;
        }

        // Add new Persons
        public async Task AddPerson(Person person) => await _repository.AddPersonAsync(person);

        // Get All Persons
        public async Task<IEnumerable<Person>> GetAllPersons() => await _repository.GetAllPersonsAsync();
               
        // Get Person by id, name, age, country or combination of different search criterias
        public async Task<Person> GetPerson(string search_criteria, string search_option) => await _repository.GetPersonAsync(search_criteria, search_option);

        // Remove a single persons
        public async Task<bool> RemovePerson(Person person) => await _repository.RemovePersonAsync(person);

        // Update just a single persons details
        public async Task<bool> UpdatePerson(Person person) => await _repository.UpdatePersonAsync(person);

        // [Testing]
        //public async Task<bool> RemoveAllPersonsAsync() => await _repository.RemoveAllPersonsAsync();
    }
}
