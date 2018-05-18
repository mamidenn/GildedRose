namespace GildedRose
{
    public static class ItemExtension
    {
        internal static void UpdateSellIn(this Item item)
        {
            var strategy = item.GetUpdateStrategy();
            strategy.UpdateSellIn(item);
        }

        public static void HandleExpiredSellIn(this Item item)
        {
            var strategy = item.GetUpdateStrategy();
            strategy.HandleExpiredSellIn(item);
        }

        public static void UpdateQuality(this Item item)
        {
            var strategy = item.GetUpdateStrategy();
            strategy.UpdateQuality(item);
        }

        private static IUpdatesItems GetUpdateStrategy(this Item item)
        {
            if (item.Name.StartsWith("Backstage passes"))
                return new BackstagePassStrategy();
            if (item.Name.StartsWith("Conjured"))
                return new ConjuredItemStrategy();
            if (item.Name == "Aged Brie")
                return new AgedBrieStrategy();
            if (item.Name == "Sulfuras, Hand of Ragnaros")
                return new LegendaryItemStrategy();
            return new DefaultUpdateStrategy();
        }
    }
}