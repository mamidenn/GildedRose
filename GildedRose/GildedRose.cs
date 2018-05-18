using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private readonly IList<Item> Items;

        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.UpdateQuality();
                item.UpdateSellIn();
                if (item.SellIn < 0)
                    item.HandleExpiredSellIn();
            }
        }
    }
}