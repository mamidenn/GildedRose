namespace GildedRose
{
    internal class ConjuredItemStrategy : UpdateStrategy
    {
        public override void DecreaseQuality(Item item)
        {
            DecreaseQuality(item, 2);
        }
    }
}