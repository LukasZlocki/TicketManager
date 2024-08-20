using System.ComponentModel.DataAnnotations;

namespace TicketManager.Models.Models
{
    public class ProductFamily
    {
        [Key]
        public int ProductFamilyId { get; set; }
        [StringLength(15)]
        public string? FamilyDescription { get; set; }

        public ICollection<ProductType> ProductType { get; set; } = null!;
        public ICollection<ProductDisplacement> ProductDisplacement { get; set; } = null!;

    }
}
