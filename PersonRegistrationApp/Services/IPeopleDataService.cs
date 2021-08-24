using PersonRegistrationShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonRegistrationApp.Services
{
    public interface IPeopleDataService
    {
        Task<IEnumerable<Person>> GetAllPeople();
        Task<Person> GetPersonDetails(int personId);
        Task<Person> AddPerson(Person person);
        Task UpdatePerson(Person person);
        Task DeletePerson(int personId);
    }
}
