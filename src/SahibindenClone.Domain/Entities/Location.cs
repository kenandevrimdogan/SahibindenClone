using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SahibindenClone.Domain.Enums;

namespace SahibindenClone.Domain.Entities;

public class Location : BaseEntity
{
    [Required, MaxLength(100)]
    public string Name { get; set; }
        
    [Required, MaxLength(150)]
    public string Slug { get; set; }
        
    public Guid? ParentId { get; set; }
        
    [Required]
    public LocationLevel Level { get; set; }
        
    [Column(TypeName = "decimal(10,8)")]
    public decimal? Latitude { get; set; }
        
    [Column(TypeName = "decimal(11,8)")]
    public decimal? Longitude { get; set; }
        
    [MaxLength(10)]
    public string PostalCode { get; set; }
        
    // Navigation Properties
    [ForeignKey("ParentId")]
    public virtual Location Parent { get; set; }
    public virtual ICollection<Location> Children { get; set; }
    public virtual ICollection<Listing> Listings { get; set; }
}