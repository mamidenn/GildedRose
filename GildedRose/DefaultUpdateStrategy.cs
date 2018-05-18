using System;
using GildedRose.Properties;

namespace GildedRose
{
    internal class DefaultUpdateStrategy : IUpdatesItems
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
            item.Quality = Math.Max(item.Quality - 1, Resources.Item_MinQuality);
        }
    }
}