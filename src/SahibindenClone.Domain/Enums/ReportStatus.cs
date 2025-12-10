namespace SahibindenClone.Domain.Enums;

public enum ReportStatus
{
    Pending = 1,         // İnceleniyor
    Investigating = 2,   // Araştırılıyor
    Resolved = 3,        // Çözüldü
    Rejected = 4,        // Reddedildi
    ActionTaken = 5      // İşlem Yapıldı
}