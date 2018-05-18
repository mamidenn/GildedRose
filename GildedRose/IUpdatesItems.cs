namespace GildedRose
{
    internal interface IUpdatesItems
    {
        void UpdateQuality(Item item);
        void UpdateSellIn(Item item);
        void HandleExpiredSellIn(Item item);
    }
}