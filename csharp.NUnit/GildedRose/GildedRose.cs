using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
            {
                continue;
            }

            Items[i].SellIn -= 1;

            if (Items[i].Name == "Aged Brie")
            {
                AgedBrieItem(Items[i]);

                continue;
            }

            if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                BackstagePassItem(Items[i]);

                continue;
            }

            if (Items[i].Name == "Conjured Mana Cake")
            {
                ConjuredItem(Items[i]);

                continue;
            }

            
            if (Items[i].SellIn >= 0)
            {
                if (Items[i].Quality > 0)
                {
                    Items[i].Quality -= 1;
                }
            }
            else
            {
                if (Items[i].Quality > 1)
                {
                    Items[i].Quality -= 2;
                }
                else if (Items[i].Quality > 0)
                {
                    Items[i].Quality -= 1;
                }
            }
        }
    }

    private void BackstagePassItem(Item item)
    {
        if (item.SellIn >= 10)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }
        else if (item.SellIn >= 5)
        {
            if (item.Quality < 49)
            {
                item.Quality += 2;
            }
            else if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }
        else if (item.SellIn >= 0 && item.SellIn <= 5)
        {
            if (item.Quality < 48)
            {
                item.Quality += 3;
            }
            else if (item.Quality < 49)
            {
                item.Quality += 2;
            }
            else if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }
        else
        {
            item.Quality = 0;
        }
    }

    private void ConjuredItem(Item item)
    {
        if (item.Quality > 1)
        {
            item.Quality -= 2;
        }
        else if (item.Quality > 0)
        {
            item.Quality -= 1;
        }
    }

    private void AgedBrieItem(Item item)
    {
        if (item.Quality < 50)
        {
            if (item.SellIn >= 0)
            {
                item.Quality += 1;
            }
            else
            {
                item.Quality += 2;
            }
        }
    }
}