using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore
{
    public class ItemManagerFactory
    {
        /* Factory creates specific items depending on the item name */
        public ItemManager CreateItem(string name, int sellIn, int quality)
        {
            switch(name)
            {
                case "Aged Brie":
                    return new AgedBrieItemManager(name, sellIn, quality);

                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePassItemManager(name, sellIn, quality);

                case "Sulfuras, Hand of Ragnaros":
                    return new LegendaryItemManager(name, sellIn, quality);

                case "Conjured Mana Cake":
                    return new ConjuredItemManager(name, sellIn, quality);

                default:
                    return new OrdinaryItemManager(name, sellIn, quality);
            }
        }
    }
}
