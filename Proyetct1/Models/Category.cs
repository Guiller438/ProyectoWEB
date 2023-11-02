using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Proyetct1.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(0, ErrorMessage = "El nombre es invalido")]
        [DisplayName("Nombre de la Categoria")]
        public string Name { get; set; }


        [DisplayName("Display Order")]
        [Range(1, 10, ErrorMessage = "El valor es invalido")]
        public int DisplayOrder { get; set; }
    }
}
