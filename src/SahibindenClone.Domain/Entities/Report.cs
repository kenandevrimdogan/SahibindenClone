using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SahibindenClone.Domain.Enums;

namespace SahibindenClone.Domain.Entities;

public class Report : AuditableEntity
{
    [Required]
    public Guid ListingId { get; set; }
        
    [Required]
    public Guid ReporterId { get; set; }
        
    [Required]
    public ReportType ReportType { get; set; }
        
    [Required]
    public ReportStatus Status { get; set; }
        
    [Required]
    public string Description { get; set; }
        
    [MaxLength(1000)]
    public string AdminNote { get; set; }
        
    public Guid? ReviewedBy { get; set; }
    public DateTime? ReviewedAt { get; set; }
        
    // Navigation Properties
    [ForeignKey("ListingId")]
    public virtual Listing Listing { get; set; }
        
    [ForeignKey("ReporterId")]
    public virtual User Reporter { get; set; }
}