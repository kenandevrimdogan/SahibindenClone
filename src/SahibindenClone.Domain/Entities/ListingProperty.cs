using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SahibindenClone.Domain.Entities;

public class ListingProperty : BaseEntity
{
    [Required]
    public Guid ListingId { get; set; }
        
    [Required]
    public Guid PropertyDefinitionId { get; set; }
        
    public string Value { get; set; }
        
    [Column(TypeName = "decimal(18,2)")]
    public decimal? ValueNumeric { get; set; }
        
    public bool? ValueBoolean { get; set; }
        
    public DateTime? ValueDate { get; set; }
        
    // Navigation Properties
    [ForeignKey("ListingId")]
    public virtual Listing Listing { get; set; }
        
    [ForeignKey("PropertyDefinitionId")]
    public virtual PropertyDefinition PropertyDefinition { get; set; }
}