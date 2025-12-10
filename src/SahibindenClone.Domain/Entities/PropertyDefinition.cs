using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SahibindenClone.Domain.Enums;

namespace SahibindenClone.Domain.Entities;

public class PropertyDefinition : BaseEntity
{
    [Required]
    public Guid CategoryId { get; set; }
        
    [Required, MaxLength(100)]
    public string Name { get; set; }
        
    [Required, MaxLength(100)]
    public string Key { get; set; }
        
    [Required]
    public PropertyDataType DataType { get; set; }
        
    [Required]
    public InputType InputType { get; set; }
        
    public bool IsRequired { get; set; }
    public bool IsFilterable { get; set; }
    public bool IsSearchable { get; set; }
        
    [Column(TypeName = "jsonb")]
    public string ValidationRules { get; set; }
        
    [Column(TypeName = "jsonb")]
    public string Options { get; set; }
        
    [MaxLength(20)]
    public string Unit { get; set; }
        
    [MaxLength(500)]
    public string Placeholder { get; set; }
        
    [MaxLength(1000)]
    public string HelpText { get; set; }
        
    public int Order { get; set; }
        
    // Navigation Properties
    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; }
    public virtual ICollection<ListingProperty> ListingProperties { get; set; }
}