using Ecommerce.Enums;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModels
{
    public class CreateCategoryViewModels
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }
        public Status Status { get; set; }

    }
}
