using Microsoft.AspNetCore.Components.Forms;
using MVC_CRUD.Entities.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD.Models.DTO_s
{
    public class CreatePersonDTO
    {
        [MaxLength(60, ErrorMessage = "Maksimum karakter sınırını aştınız!")]
        [DisplayName("Ad")]
        [Required(ErrorMessage = "Bu alan boş geçilemez!!")]
        public string Name { get; set; }

        
        [MaxLength(60, ErrorMessage = "Maksimum karakter sınırını aştınız!")]
        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Bu alan boş geçilemez!!")]
        public string Surname { get; set; }

        
        [DisplayName("Doğum Tarihi")]
        [Required(ErrorMessage = "Bu alan boş geçilemez!!")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }


        [DisplayName("Cinsiyet")]
        [Required(ErrorMessage = "Bu alan boş geçilemez!!")]
        public Gender Gender { get; set; }
    }
}
