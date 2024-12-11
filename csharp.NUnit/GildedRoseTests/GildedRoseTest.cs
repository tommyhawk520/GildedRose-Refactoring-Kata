using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void SystemLowersSellInDateAndQualityAtEndOfDay()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(9));
        Assert.That(items[0].Quality, Is.EqualTo(19));
    }

    [Test]
    public void SystemLowersQualityTwiceAsFastWhenSellInDateHasPassed()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 20 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(18));
    }

    [Test]
    public void QualityIsNeverNegative()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }

    [Test]
    public void QualityOfAgedBrieIncreases()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(11));
    }

    [Test]
    public void QualityOfAgedBrieIncreasesDoubleAfterSellinDate()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -1, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(12));
    }

    [Test]
    public void QualityDoesNotExceed50()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(50));
    }

    [Test]
    public void LegendaryItemNeverDecreasesInQuality()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(80));
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
    }

    [Test]
    public void BackstagePassQualityIncreasesBy2WhenSellinIsLessThan10()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(12));
    }

    [Test]
    public void BackstagePassQualityIncreasesBy3WhenSellinIsLessThan5()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(13));
    }

    [Test]
    public void BackstagePassQualityDecreasesTo0WhenSellinIs0()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }

    [Test]
    public void ConjouredItemQualityLowersby2()
    {
        var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(8));
    }
}