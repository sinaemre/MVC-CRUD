using MVC_CRUD.Entities.Concrete;
using MVC_CRUD.Infrastructure.Context;
using MVC_CRUD.Infrastructure.Services.Interface;
using System.Linq.Expressions;

namespace MVC_CRUD.Infrastructure.Services.Concrete
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        //Dependency Injection
        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Person entity)
        {
            _context.People.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Person entity)
        {
            var person = _context.People.FirstOrDefault(x => x.Id == entity.Id);
            if (person != null) 
            {
                person.Status = Entities.Abstract.Status.Passive;
                person.DeletedDate = DateTime.Now;
                _context.People.Update(person);
                _context.SaveChanges();
            }
        }
        
        public void Update(Person entity)
        {
            var person = _context.People.FirstOrDefault(x => x.Id == entity.Id);
            if (person != null)
            {
                person.Name = entity.Name;
                person.Surname = entity.Surname;
                person.Birthdate = entity.Birthdate;
                person.Gender = entity.Gender;
                person.Status = Entities.Abstract.Status.Modified;
                person.UpdatedDate = DateTime.Now;
                _context.People.Update(person);
                _context.SaveChanges();
            }

        }

        public Person GetByDefault(Expression<Func<Person, bool>> expression)
        {
            var person = _context.People.FirstOrDefault(expression);
            if (person != null)
            {
                return person;
            }
            return null;
        }

        public List<Person> GetByDefaults(Expression<Func<Person, bool>> expression)
        {
            var people = _context.People.Where(expression).ToList();
            return people;
        }

      
    }
}
