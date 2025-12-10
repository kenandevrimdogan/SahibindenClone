using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SahibindenClone.Domain.Enums;

namespace SahibindenClone.Domain.Entities;

public class Message : BaseEntity
{
    [Required]
    public Guid ListingId { get; set; }
        
    [Required]
    public Guid SenderId { get; set; }
        
    [Required]
    public Guid ReceiverId { get; set; }
        
    [Required]
    public string Content { get; set; }
        
    public MessageStatus Status { get; set; }
        
    public DateTime? ReadAt { get; set; }
        
    // Navigation Properties
    [ForeignKey("ListingId")]
    public virtual Listing Listing { get; set; }
        
    [ForeignKey("SenderId")]
    public virtual User Sender { get; set; }
        
    [ForeignKey("ReceiverId")]
    public virtual User Receiver { get; set; }
}