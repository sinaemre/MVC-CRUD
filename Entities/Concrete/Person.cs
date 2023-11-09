using MVC_CRUD.Entities.Abstract;

namespace MVC_CRUD.Entities.Concrete
{
    public enum Gender { Kadın, Erkek }
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }

        private Gender _gender;
        public Gender Gender 
        {
            get => _gender;
            set => _gender = value;
        }
    }
}
