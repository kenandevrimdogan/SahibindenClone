using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SahibindenClone.Domain.Entities;

public class Category : BaseEntity
{
    [Required, MaxLength(100)]
    public string Name { get; set; }
        
    [Required, MaxLength(150)]
    public string Slug { get; set; }
        
    public Guid? ParentId { get; set; }
        
    [MaxLength(50)]
    public string Icon { get; set; }
        
    [MaxLength(500)]
    public string Description { get; set; }
        
    public bool IsActive { get; set; }
    public int Order { get; set; }
        
    [MaxLength(500)]
    public string MetaTitle { get; set; }
        
    [MaxLength(1000)]
    public string MetaDescription { get; set; }
        
    // Navigation Properties
    [ForeignKey("ParentId")]
    public virtual Category Parent { get; set; }
    public virtual ICollection<Category> Children { get; set; }
    public virtual ICollection<PropertyDefinition> PropertyDefinitions { get; set; }
    public virtual ICollection<Listing> Listings { get; set; }
}