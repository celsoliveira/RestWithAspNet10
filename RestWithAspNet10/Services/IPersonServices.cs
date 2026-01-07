using RestWithAspNet10.Model;

namespace RestWithAspNet10.Services
{
    public interface IPersonServices
    {
        Person Create(Person person);
        Person Update(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        void Delete(long id);

    }
}
