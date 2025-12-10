using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SahibindenClone.Domain.Enums;

namespace SahibindenClone.Domain.Entities;

public class UserPackage : BaseEntity
{
    [Required]
    public Guid UserId { get; set; }
        
    [Required]
    public Guid PackageId { get; set; }
        
    [Required]
    public Guid ListingId { get; set; }
        
    public PaymentStatus PaymentStatus { get; set; }
        
    [Column(TypeName = "decimal(18,2)")]
    public decimal AmountPaid { get; set; }
        
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
        
    public bool IsActive { get; set; }
        
    // Navigation Properties
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
        
    [ForeignKey("PackageId")]
    public virtual Package Package { get; set; }
        
    [ForeignKey("ListingId")]
    public virtual Listing Listing { get; set; }
}