using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SahibindenClone.Domain.Enums;

namespace SahibindenClone.Domain.Entities;

public class Image : BaseEntity
{
    [Required]
    public Guid ListingId { get; set; }
        
    [Required, MaxLength(500)]
    public string Url { get; set; }
        
    [MaxLength(500)]
    public string ThumbnailUrl { get; set; }
        
    public ImageType ImageType { get; set; }
        
    public int Order { get; set; }
    public bool IsPrimary { get; set; }
        
    [MaxLength(200)]
    public string AltText { get; set; }
        
    public int? Width { get; set; }
    public int? Height { get; set; }
    public long? FileSize { get; set; }
        
    // Navigation Properties
    [ForeignKey("ListingId")]
    public virtual Listing Listing { get; set; }
}