using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void UpdateQuality_ItemNamesArePreserved()
        {
            IList<Item> items = new List<Item> { new Item { Name = "TEST", SellIn = 0, Quality = 0 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual("TEST", items[0].Name);
        }

        [Test]
        public void UpdateQuality_Item_SellInValueDecreases([Random(1, int.MaxValue, 50)] int startSellIn)
        {
            IList<Item> items = new List<Item> { new Item { Name = "TEST", SellIn = startSellIn, Quality = 0 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Less(items[0].SellIn, startSellIn);
        }

        [Test]
        public void UpdateQuality_Item_QualityValueDecreases([Range(1, 50)] int startQuality)
        {
            IList<Item> items = new List<Item> { new Item { Name = "TEST", SellIn = 0, Quality = startQuality } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Less(items[0].Quality, startQuality);
        }

        [Test]
        public void UpdateQuality_Item_QualityIsNeverNegative([Range(0, 50)] int startQuality)
        {
            IList<Item> items = new List<Item> { new Item { Name = "TEST", SellIn = 0, Quality = startQuality } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.GreaterOrEqual(items[0].Quality, 0);
        }

        [Test]
        public void UpdateQuality_Item_QualityDegradesTwiceAfterSellByDate([Range(2, 50)] int startQuality)
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "BEFORE_SELL_BY", SellIn = 1, Quality = startQuality },
                new Item { Name = "AFTER_SELL_BY", SellIn = 0, Quality = startQuality }
            };
            var app = new GildedRose(items);

            app.UpdateQuality();

            var beforeSellByDelta = startQuality - items[0].Quality;
            var afterSellByDelta = startQuality - items[1].Quality;
            Assert.That(afterSellByDelta.Equals(beforeSellByDelta * 2));
        }

        [Test]
        public void UpdateQuality_Item_QualityIsNeverGreater50([Range(0, 50)] int startQuality)
        {
            IList<Item> items = new List<Item> { new Item { Name = "TEST", SellIn = 0, Quality = startQuality } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.LessOrEqual(items[0].Quality, 50);
        }

        [Test]
        public void UpdateQuality_AgedBrie_QualityIncreases([Range(0, 49)] int startQuality)
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = startQuality } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Greater(items[0].Quality, startQuality);
        }

        [Test]
        public void UpdateQuality_Sulfuras_QualityDoesNotChange([Range(0, 50)] int startQuality)
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = startQuality } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(startQuality, items[0].Quality);
        }

        [Test]
        public void UpdateQuality_Sulfuras_SellInDoesNotChange([Random(1, int.MaxValue, 50)] int startSellIn)
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = startSellIn, Quality = 0 } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(startSellIn, items[0].SellIn);
        }

        [Test]
        public void UpdateQuality_BackstagePasses_QualityIncreaseBy2IfSellByBetween6and10([Range(6, 10)] int startSellIn, [Random(0, 48, 10)] int startQuality)
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = startSellIn, Quality = startQuality } };
            var app = new GildedRose(items);

            app.UpdateQuality();
            var qualityDelta = items[0].Quality - startQuality;

            Assert.AreEqual(2, qualityDelta);
        }

        [Test]
        public void UpdateQuality_BackstagePasses_QualityIncreaseBy3IfSellByBetween1and5([Range(1, 5)] int startSellIn, [Random(0, 47, 10)] int startQuality)
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = startSellIn, Quality = startQuality } };
            var app = new GildedRose(items);

            app.UpdateQuality();
            var qualityDelta = items[0].Quality - startQuality;

            Assert.AreEqual(3, qualityDelta);
        }

        [Test]
        public void UpdateQuality_BackstagePasses_QualityIs0IfSellInIs0([Range(0, 50)] int startQuality)
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = startQuality } };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(0, items[0].Quality);
        }
    }
}
