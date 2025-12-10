using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SahibindenClone.Domain.Entities;

public class Favorite : BaseEntity
{
    [Required]
    public Guid UserId { get; set; }
        
    [Required]
    public Guid ListingId { get; set; }
        
    [MaxLength(500)]
    public string Note { get; set; }
        
    // Navigation Properties
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
        
    [ForeignKey("ListingId")]
    public virtual Listing Listing { get; set; }
}