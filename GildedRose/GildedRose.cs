using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private IList<Item> Items;

        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.DoesIncreaseQuality())
                    item.IncreaseQuality();
                else
                    item.DecreaseQuality();

                item.DecreaseSellIn();

                if (item.SellIn < 0) item.HandleExpiredSellIn();
            }
        }
    }
}