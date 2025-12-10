namespace SahibindenClone.Domain.Enums;

public enum NotificationType
{
    NewMessage = 1,      // Yeni Mesaj
    ListingApproved = 2, // İlan Onaylandı
    ListingRejected = 3, // İlan Reddedildi
    ListingExpiring = 4, // İlan Süresi Dolmak Üzere
    ListingExpired = 5,  // İlan Süresi Doldu
    FavoriteListingUpdated = 6, // Favori İlan Güncellendi
    PriceDropped = 7,    // Fiyat Düştü
    NewComment = 8,      // Yeni Yorum
    SystemAlert = 9      // Sistem Uyarısı
}