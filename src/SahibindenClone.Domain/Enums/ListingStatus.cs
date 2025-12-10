namespace SahibindenClone.Domain.Enums;

public enum ListingStatus
{
    Draft = 1,           // Taslak
    PendingApproval = 2, // Onay Bekliyor
    Active = 3,          // Yayında
    Sold = 4,            // Satıldı
    Rented = 5,          // Kiralandı
    Expired = 6,         // Süresi Doldu
    Rejected = 7,        // Reddedildi
    Paused = 8,          // Durduruldu
    Deleted = 9          // Silindi
}