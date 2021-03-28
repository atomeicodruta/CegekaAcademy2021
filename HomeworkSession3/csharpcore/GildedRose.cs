using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        /* Update the state of the items in the store */
        public void UpdateQuality()
        {
            foreach (ItemManager item in Items)
            {
                item.ItemStateUpdate();
            }
        }
    }
}
