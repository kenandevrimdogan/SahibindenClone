using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SahibindenClone.Domain.Enums;

namespace SahibindenClone.Domain.Entities;

public class SavedSearch : BaseEntity
{
    [Required]
    public Guid UserId { get; set; }
        
    [Required, MaxLength(200)]
    public string Name { get; set; }
        
    public Guid? CategoryId { get; set; }
        
    [Column(TypeName = "jsonb")]
    public string SearchCriteria { get; set; }
        
    public NotificationFrequency NotificationFrequency { get; set; }
        
    public bool IsActive { get; set; }
        
    public DateTime? LastNotifiedAt { get; set; }
        
    // Navigation Properties
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
        
    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; }
}