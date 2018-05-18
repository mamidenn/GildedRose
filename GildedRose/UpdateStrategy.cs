using System;

namespace GildedRose
{
    internal class UpdateStrategy
    {
        public bool DoesIncreaseQuality { get; protected set; }

        public virtual void IncreaseQuality(Item item)
        {
            IncreaseQuality(item, 1);
        }

        protected static void IncreaseQuality(Item item, int amount)
        {
            item.Quality = Math.Min(item.Quality + amount, 50);
        }

        public virtual void DecreaseQuality(Item item)
        {
            DecreaseQuality(item, 1);
        }

        protected static void DecreaseQuality(Item item, int amount)
        {
            item.Quality = Math.Max(item.Quality - amount, 0);
        }

        public virtual void DecreaseSellIn(Item item)
        {
            item.SellIn -= 1;
        }

        public virtual void HandleExpiredSellIn(Item item)
        {
            item.DecreaseQuality();
        }
    }
}