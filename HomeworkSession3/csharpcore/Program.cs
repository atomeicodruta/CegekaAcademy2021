using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            /* Use a factory design to create the different types of items in our store */
            ItemManagerFactory itemFactory = new ItemManagerFactory();

            IList<Item> Items = new List<Item>{
                itemFactory.CreateItem("+5 Dexterity Vest", 10, 20),
                itemFactory.CreateItem("Aged Brie", 2, 0),
                itemFactory.CreateItem("Elixir of the Mongoose", 5, 7),
                itemFactory.CreateItem("Sulfuras, Hand of Ragnaros", 0, 80),
                itemFactory.CreateItem("Sulfuras, Hand of Ragnaros", -1, 80),
                itemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                itemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 10, 49),
                itemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 5, 49),
                itemFactory.CreateItem("Conjured Mana Cake", 3, 6),
            };

            /* Create new store object selling the list of items from above */
            var app = new GildedRose(Items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
