namespace SahibindenClone.Domain.Enums;

public enum VerificationStatus
{
    NotVerified = 1,     // Doğrulanmadı
    Pending = 2,         // Bekliyor
    Verified = 3,        // Doğrulandı
    Rejected = 4         // Reddedildi
}