using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore
{
    /* Class that manages the state of the items */
    public abstract class ItemManager : Item
    {
        protected const int MAX_QUALITY = 50;
        protected const int MIN_QUALITY = 0;

        public ItemManager(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public abstract void ItemStateUpdate();
    }

    public class OrdinaryItemManager : ItemManager
    {
        public OrdinaryItemManager(string name, int sellIn, int quality) : base(name, sellIn, quality) { }

        public override void ItemStateUpdate()
        {
            /* Update sell in value */
            SellIn--;

            /* Update quality value */
            if (Quality > MIN_QUALITY)
            {
                Quality--;
            }

            /* Account for the twice degrading quality once the sell in date has passed */
            if (SellIn < 0)
            {
                if (Quality > MIN_QUALITY)
                {
                    Quality--;
                }
            }
        }
    }

    public class AgedBrieItemManager : ItemManager
    {
        public AgedBrieItemManager(string name, int sellIn, int quality) : base(name, sellIn, quality) { }

        public override void ItemStateUpdate()
        {
            /* Update sell in value */
            SellIn--;

            /* Update quality as long as it hasn't reached its maximum value */
            if (Quality < MAX_QUALITY)
            {
                Quality++;
            }
            if((SellIn < 0) && (Quality < MAX_QUALITY))
            {
                Quality++;
            }
        }
    }

    public class LegendaryItemManager : ItemManager
    {
        public LegendaryItemManager(string name, int sellIn, int quality) : base(name, sellIn, quality) { }

        public override void ItemStateUpdate()
        {
        }
    }

    public class BackstagePassItemManager : ItemManager
    {
        public BackstagePassItemManager(string name, int sellIn, int quality) : base(name, sellIn, quality) { }

        public override void ItemStateUpdate()
        {
            /* Update sell in value */
            SellIn--;

            /* Update quality by one/two/three increments depending on the no. of days left untill the concert */
            if (SellIn > 0)
            {
                if (Quality < MAX_QUALITY)
                {
                    Quality++;
                }

                if (SellIn < 10)
                {
                    if (Quality < MAX_QUALITY)
                    {
                        Quality++;
                    }
                }

                if (SellIn < 5)
                {
                    if (Quality < MAX_QUALITY)
                    {
                        Quality++;
                    }
                }
            }
            else if (Quality != MIN_QUALITY)
            {
                Quality = MIN_QUALITY;
            }
        }
    }

    public class ConjuredItemManager : ItemManager
    {
        public ConjuredItemManager(string name, int sellIn, int quality) : base(name, sellIn, quality) { }

        public override void ItemStateUpdate()
        {
            /* Update sell in value */
            SellIn--;

            if (Quality > MIN_QUALITY)
            {
                if (SellIn > 0)
                {
                    Quality -= 2;
                }
                if (SellIn <= 0)
                {
                    Quality -= 4;
                }
            }

            if (Quality < MIN_QUALITY)
            {
                Quality = MIN_QUALITY;
            }
        }
    }


}