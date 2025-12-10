namespace SahibindenClone.Domain.Enums;

public enum PropertyDataType
{
    String = 1,          // Metin
    Number = 2,          // Sayı
    Decimal = 3,         // Ondalıklı Sayı
    Boolean = 4,         // Evet/Hayır
    Date = 5,            // Tarih
    DateTime = 6,        // Tarih ve Saat
    Select = 7,          // Tekli Seçim
    MultiSelect = 8,     // Çoklu Seçim
    Email = 9,           // Email
    Phone = 10,          // Telefon
    Url = 11             // URL
}