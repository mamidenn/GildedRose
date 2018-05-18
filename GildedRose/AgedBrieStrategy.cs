using System;
using GildedRose.Properties;

namespace GildedRose
{
    internal class AgedBrieStrategy : IUpdatesItems
    {
        public void HandleExpiredSellIn(Item item)
        {
            IncreaseQuality(item);
        }

        public void UpdateSellIn(Item item)
        {
            item.SellIn -= 1;
        }

        public void UpdateQuality(Item item)
        {
            IncreaseQuality(item);
        }

        private static void IncreaseQuality(Item item)
        {
            item.Quality = Math.Min(item.Quality + 1, Resources.Item_MaxQuality);
        }
    }
}