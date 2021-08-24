using PersonRegistrationShared;
using System.Collections.Generic;
using System.Linq;

namespace PersonRegistrationAPI.Models
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _appDbContext;

        public PersonRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _appDbContext.People;
        }

        public Person GetPersonById(int personId)
        {
            return _appDbContext.People.FirstOrDefault(c => c.PersonId == personId);
        }

        public Person AddPerson(Person person)
        {
            var addedEntity = _appDbContext.People.Add(person);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Person UpdatePerson(Person person)
        {
            var foundPerson = _appDbContext.People.FirstOrDefault(e => e.PersonId == person.PersonId);

            if (foundPerson != null)
            {
                foundPerson.BirthDate = person.BirthDate;
                foundPerson.City = person.City;
                foundPerson.Email = person.Email;
                foundPerson.FirstName = person.FirstName;
                foundPerson.LastName = person.LastName;
                foundPerson.Street = person.Street;
                foundPerson.Zip = person.Zip;

                _appDbContext.SaveChanges();

                return foundPerson;
            }

            return null;
        }

        public void DeletePerson(int personId)
        {
            var foundPerson = _appDbContext.People.FirstOrDefault(e => e.PersonId == personId);
            if (foundPerson == null) return;

            _appDbContext.People.Remove(foundPerson);
            _appDbContext.SaveChanges();
        }
    }
}
