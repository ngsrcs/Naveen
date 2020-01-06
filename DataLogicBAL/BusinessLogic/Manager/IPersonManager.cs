using System.Collections.Generic;
using System.Threading.Tasks;
using NaveenWPFApp.DataAccessDAL.DTO.Models;

namespace DataLogicBAL.BusinessLogic.Manager
{
    public interface IPersonManager
    {
        // Get All Persons
        Task<IEnumerable<Person>> GetAllPersons();

        // Get Person by id, name, age, country or combination of different search criterias
        Task<Person> GetPerson(string search_criteria, string search_option);

        // Add new Persons
        Task AddPerson(Person person);

        // Remove a single persons
        Task<bool> RemovePerson(Person person);

        // Update just a single persons details
        Task<bool> UpdatePerson(Person person);

        // [Testing] - Remove 
        //Task<bool> RemoveAllPersons();
    }
}