using System;
using GildedRose.Properties;

namespace GildedRose
{
    internal class BackstagePassStrategy : IUpdatesItems
    {
        public void HandleExpiredSellIn(Item item)
        {
            item.Quality = Resources.Item_MinQuality;
        }

        public void UpdateSellIn(Item item)
        {
            item.SellIn -= 1;
        }

        public void UpdateQuality(Item item)
        {
            int increaseAmount;
            if (Resources.BackstagePass_SecondQualityIncreaseThreshold < item.SellIn
                && item.SellIn <= Resources.BackstagePass_FirstQualityIncreaseThreshold)
                increaseAmount = 2;
            else if (item.SellIn <= Resources.BackstagePass_SecondQualityIncreaseThreshold)
                increaseAmount = 3;
            else
                increaseAmount = 1;
            item.Quality = Math.Min(item.Quality + increaseAmount, Resources.Item_MaxQuality);
        }
    }
}