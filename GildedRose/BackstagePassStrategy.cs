namespace GildedRose
{
    internal class BackstagePassStrategy : UpdateStrategy
    {
        public BackstagePassStrategy()
        {
            DoesIncreaseQuality = true;
        }

        public override void IncreaseQuality(Item item)
        {
            int increaseAmount;
            if (5 < item.SellIn && item.SellIn <= 10)
                increaseAmount = 2;
            else if (item.SellIn <= 5)
                increaseAmount = 3;
            else
                increaseAmount = 1;
            IncreaseQuality(item, increaseAmount);
        }

        public override void HandleExpiredSellIn(Item item)
        {
            item.Quality = 0;
        }
    }
}