using MVC_CRUD.Entities.Abstract;
using MVC_CRUD.Entities.Concrete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC_CRUD.Models.ViewModels
{
    public class DetailPersonVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public Status Status { get; set; }
    }
}
