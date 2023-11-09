using MVC_CRUD.Entities.Concrete;
using System.Linq.Expressions;

namespace MVC_CRUD.Infrastructure.Services.Interface
{
    public interface IPersonRepository
    {
        void Add(Person entity);
        void Update(Person entity);
        void Delete(Person entity);


        //Read Operations
        //Expression => Where, FirstOrDefault gibi linq methodlarını içerisine doğrudan verebileceğimiz "=>"(lamba) işareti ile birlikte kullanılan cümlecikler.
        //Örnek x => x.Id == 5 bu bir expression'dır.
        Person GetByDefault(Expression<Func<Person, bool>> expression);
        List<Person> GetByDefaults(Expression<Func<Person, bool>> expression);
    }
}
