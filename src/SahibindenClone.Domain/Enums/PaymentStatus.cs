namespace SahibindenClone.Domain.Enums;

public enum PaymentStatus
{
    Pending = 1,         // Bekliyor
    Processing = 2,      // İşleniyor
    Completed = 3,       // Tamamlandı
    Failed = 4,          // Başarısız
    Cancelled = 5,       // İptal Edildi
    Refunded = 6         // İade Edildi
}