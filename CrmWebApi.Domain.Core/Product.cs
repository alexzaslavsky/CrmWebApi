using System.ComponentModel.DataAnnotations;

namespace CrmWebApi.Domain.Core
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }
    }
}
