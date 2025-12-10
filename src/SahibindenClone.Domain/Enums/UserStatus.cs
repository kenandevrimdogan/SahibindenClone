namespace SahibindenClone.Domain.Enums;

public enum UserStatus
{
    Pending = 1,         // Onay Bekliyor
    Active = 2,          // Aktif
    Suspended = 3,       // Askıya Alınmış
    Banned = 4,          // Yasaklanmış
    Deleted = 5          // Silinmiş
}