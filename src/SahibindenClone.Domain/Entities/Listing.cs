using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SahibindenClone.Domain.Enums;

namespace SahibindenClone.Domain.Entities;

public class Listing : AuditableEntity
{
    [Required]
    public Guid UserId { get; set; }
        
    [Required]
    public Guid CategoryId { get; set; }
        
    [Required, MaxLength(200)]
    public string Title { get; set; }
        
    [Required]
    public string Description { get; set; }
        
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
        
    [Required]
    public Currency Currency { get; set; }
        
    [Required]
    public ListingStatus Status { get; set; }
        
    public int ViewCount { get; set; }
    public int FavoriteCount { get; set; }
        
    public Guid? LocationId { get; set; }
        
    public bool IsFeatured { get; set; }
    public bool IsUrgent { get; set; }
        
    [MaxLength(100)]
    public string ListingCode { get; set; }
        
    public DateTime? FeaturedUntil { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public DateTime? PublishedAt { get; set; }
        
    // Navigation Properties
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
        
    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; }
        
    [ForeignKey("LocationId")]
    public virtual Location Location { get; set; }
        
    public virtual ICollection<ListingProperty> Properties { get; set; }
    public virtual ICollection<Image> Images { get; set; }
    public virtual ICollection<Favorite> Favorites { get; set; }
    public virtual ICollection<Message> Messages { get; set; }
    public virtual ICollection<Report> Reports { get; set; }
}