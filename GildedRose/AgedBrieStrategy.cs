namespace GildedRose
{
    internal class AgedBrieStrategy : UpdateStrategy
    {
        internal AgedBrieStrategy()
        {
            DoesIncreaseQuality = true;
        }

        public override void HandleExpiredSellIn(Item item)
        {
            item.IncreaseQuality();
        }
    }
}