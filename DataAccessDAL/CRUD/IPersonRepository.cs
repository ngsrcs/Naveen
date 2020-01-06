using System.Collections.Generic;
using System.Threading.Tasks;
using NaveenWPFApp.DataAccessDAL.DTO.Models;

namespace DataAccessDAL.CRUD
{
    public interface IPersonRepository
    {        
        // Get All Persons
        Task<IEnumerable<Person>> GetAllPersonsAsync();

        // Get Person by id, name, age, country or combination of different search criterias
        Task<Person> GetPersonAsync(string search_criteria, string search_option);

        // Add new Persons
        Task AddPersonAsync(Person person);

        // Remove a single persons
        Task<bool> RemovePersonAsync(Person person);

        // Update just a single persons details
        Task<bool> UpdatePersonAsync(Person person);

        // [Testing] - Remove 
        Task<bool> RemoveAllPersonsAsync();
    }
}
