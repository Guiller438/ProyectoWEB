using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Proyetct11.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(0, ErrorMessage = "El nombre es invalido")]
        [DisplayName("Nombre del producto")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Barcode { get; set; }
        [Required]
        public string Seller { get; set; }
        [Required]
        [Display(Name ="Lista de precios")]
        [Range(1,1000)]
        public double ListPrice {  get; set; }

        [Required]
        [Display(Name = "Precios de 1-50$")]
        [Range(1, 1000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Precios de +50$")]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Precios de 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }

        public int CategoryId {  get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }   
    }
}
