namespace GildedRose
{
    public static class ItemExtension
    {
        internal static void IncreaseQuality(this Item item)
        {
            item.GetUpdateStrategy().IncreaseQuality(item);
        }

        internal static void DecreaseSellIn(this Item item)
        {
            item.GetUpdateStrategy().DecreaseSellIn(item);
        }

        internal static void DecreaseQuality(this Item item)
        {
            item.GetUpdateStrategy().DecreaseQuality(item);
        }

        public static void HandleExpiredSellIn(this Item item)
        {
            item.GetUpdateStrategy().HandleExpiredSellIn(item);
        }

        public static void UpdateQuality(this Item item)
        {
            if (item.GetUpdateStrategy().DoesIncreaseQuality)
                item.IncreaseQuality();
            else
                item.DecreaseQuality();
        }

        private static UpdateStrategy GetUpdateStrategy(this Item item)
        {
            if(item.Name.StartsWith("Backstage passes"))
                return new BackstagePassStrategy();
            if (item.Name.StartsWith("Conjured"))
                return new ConjuredItemStrategy();
            if (item.Name == "Aged Brie")
                return new AgedBrieStrategy();
            if (item.Name == "Sulfuras, Hand of Ragnaros")
                return new LegendaryItemStrategy();
            return new UpdateStrategy();
        }
    }
}