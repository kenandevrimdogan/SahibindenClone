using System.ComponentModel.DataAnnotations;
using SahibindenClone.Domain.Enums;

namespace SahibindenClone.Domain.Entities;

public class User : AuditableEntity
{
    [Required, MaxLength(100)]
    public string Email { get; set; }
        
    [Required, MaxLength(15)]
    public string Phone { get; set; }
        
    [Required]
    public string PasswordHash { get; set; }
        
    [Required, MaxLength(100)]
    public string Name { get; set; }
        
    [Required, MaxLength(100)]
    public string Surname { get; set; }
        
    [Required]
    public UserType UserType { get; set; }
        
    [Required]
    public UserStatus Status { get; set; }
        
    public VerificationStatus EmailVerificationStatus { get; set; }
    public VerificationStatus PhoneVerificationStatus { get; set; }
        
    [MaxLength(500)]
    public string ProfilePhotoUrl { get; set; }
        
    [MaxLength(1000)]
    public string Bio { get; set; }
        
    public DateTime? LastLoginAt { get; set; }
        
    // Navigation Properties
    public virtual ICollection<Listing> Listings { get; set; }
    public virtual ICollection<Favorite> Favorites { get; set; }
    public virtual ICollection<Message> SentMessages { get; set; }
    public virtual ICollection<Message> ReceivedMessages { get; set; }
    public virtual ICollection<SavedSearch> SavedSearches { get; set; }
    public virtual ICollection<Report> Reports { get; set; }
}