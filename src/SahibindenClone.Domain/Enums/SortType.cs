namespace SahibindenClone.Domain.Enums;

public enum SortType
{
    Newest = 1,          // En Yeni
    Oldest = 2,          // En Eski
    PriceLowToHigh = 3,  // Fiyat: Düşükten Yükseğe
    PriceHighToLow = 4,  // Fiyat: Yüksekten Düşüğe
    MostViewed = 5,      // En Çok Görüntülenen
    MostFavorited = 6    // En Çok Favorilenen
}