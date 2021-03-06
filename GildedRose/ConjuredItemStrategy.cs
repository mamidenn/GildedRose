using System;
using GildedRose.Properties;

namespace GildedRose
{
    internal class ConjuredItemStrategy : IUpdatesItems
    {
        public void UpdateSellIn(Item item)
        {
            item.SellIn -= 1;
        }

        public void HandleExpiredSellIn(Item item)
        {
            DecreaseQuality(item);
        }

        public void UpdateQuality(Item item)
        {
            DecreaseQuality(item);
        }

        private static void DecreaseQuality(Item item)
        {
            item.Quality = Math.Max(item.Quality - 2, Resources.Item_MinQuality);
        }
    }
}