using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SahibindenClone.Domain.Enums;

namespace SahibindenClone.Domain.Entities;

public class Package: BaseEntity
{
    [Required, MaxLength(100)]
    public string Name { get; set; }
        
    [Required]
    public PackageType PackageType { get; set; }
        
    [MaxLength(500)]
    public string Description { get; set; }
        
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
        
    public Currency Currency { get; set; }
        
    public int DurationDays { get; set; }
        
    public bool IsActive { get; set; }
        
    [Column(TypeName = "jsonb")]
    public string Features { get; set; }
        
    // Navigation Properties
    public virtual ICollection<UserPackage> UserPackages { get; set; }
}