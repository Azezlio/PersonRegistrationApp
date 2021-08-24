using PersonRegistrationShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonRegistrationAPI.Models
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAllPeople();
        Person GetPersonById(int personId);
        Person AddPerson(Person person);
        Person UpdatePerson(Person person);
        void DeletePerson(int personId);
    }
}
