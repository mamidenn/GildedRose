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
            int increaseAmount;

            switch (item.Name)
            {
                case "Backstage passes to a TAFKAL80ETC concert":
                    if (5 < item.SellIn && item.SellIn <= 10)
                        increaseAmount = 2;
                    else if (item.SellIn <= 5)
                        increaseAmount = 3;
                    else
                        increaseAmount = 1;
                    break;
                default:
                    increaseAmount = 1;
                    break;
            }

            item.Quality = Math.Min(item.Quality + increaseAmount, 50);
        }

        public static void DecreaseSellIn(this Item item)
        {
            if (item.IsLegendary())
                return;
            item.SellIn = item.SellIn - 1;
        }

        public static void DecreaseQuality(this Item item)
        {
            if (item.IsLegendary())
                return;
            int decreaseAmount;
            switch (item.Name)
            {
                case "Conjured Mana Cake":
                    decreaseAmount = 2;
                    break;
                default:
                    decreaseAmount = 1;
                    break;
            }

            item.Quality = Math.Max(item.Quality - decreaseAmount, 0);
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