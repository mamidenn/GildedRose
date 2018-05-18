using System;

namespace GildedRose
{
    internal static class ItemExtension
    {
        public static bool IsLegendary(this Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        public static void IncreaseQuality(this Item item)
        {
            var increaseAmount = 1;

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                
                if (5 < item.SellIn && item.SellIn <= 10)
                    increaseAmount = 2;
                else if (item.SellIn <= 5)
                    increaseAmount = 3;
            }

            if (item.Quality < 50)
                item.Quality = Math.Min(item.Quality + increaseAmount, 50);
        }

        public static void DecreaseSellIn(this Item item)
        {
            if (!item.IsLegendary())
                item.SellIn = item.SellIn - 1;
        }

        public static void DecreaseQuality(this Item item)
        {
            if (item.IsLegendary()) return;
            if (item.Quality > 0)
                item.Quality = item.Quality - 1;
        }

        public static bool DoesIncreaseQuality(this Item item)
        {
            return item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        public static void HandleExpiredSellIn(this Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    item.IncreaseQuality();
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    item.Quality = 0;
                    break;
                default:
                    item.DecreaseQuality();
                    break;
            }
        }
    }
}