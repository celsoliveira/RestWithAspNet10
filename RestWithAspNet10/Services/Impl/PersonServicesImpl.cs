using System;
using RestWithAspNet10.Model;
using RestWithAspNet10.Model.Context;

namespace RestWithAspNet10.Services.Impl
{
    public class PersonServicesImpl : IPersonServices
    {

        private MSSQLContext _context;

        public PersonServicesImpl(MSSQLContext context)
        {
            _context = context;
        }
        public List<Person> FindAll()
        {
            /*
             * List<Person> persons = new List<Person>();
            for(int i = 0; i < 8; i++)
            {
                persons.Add(MockPerson(1));
            }
            */
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            //Person person = MockPerson((int)id);
            return _context.Persons.Find(id);
        }

        public Person Create(Person person)
        {
           // person.Id = new Random().Next(1, 1000);
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }

        public Person Update(Person person)
        {
            var existingPerson = _context.Persons.Find(person.Id);
            if (existingPerson == null) return null;

            _context.Entry(existingPerson).CurrentValues.SetValues(person);
            _context.SaveChanges();
            return person;
        }
        
        public void Delete(long id)
        {
            var existingPerson = _context.Persons.Find(id);
            if (existingPerson == null) return;

            _context.Remove(existingPerson);
            _context.SaveChanges();
        }

    }
}
