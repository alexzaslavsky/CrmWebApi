using System.ComponentModel.DataAnnotations;

namespace CrmWebApi.ViewModels
{
    public class ProductCategoryViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(128)]
        public string Name { get; set; }
    }
}
