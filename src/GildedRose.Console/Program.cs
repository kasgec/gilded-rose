using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    class Program
    {
        IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            Program app = new Program();
            app.CreateItems();
            app.Items.ToList().ForEach(r => r.ValidateItem());

            int count = 20;
            while (count > 0)
            {
                app.UpdateQuality();
                count--;
            }

            System.Console.ReadKey();
        }

        private void CreateItems()
        {
            Items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 81},
                new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
        }

        private void UpdateProduct(Item item, int reducer)
        {
            if (item.Quality < reducer)
            {
                item.Quality = 0;
            }
            else if (item.SellIn < 0)
            {
                int toReduce;
                if ((toReduce = 2 * reducer) < item.Quality)
                {
                    item.Quality = item.Quality - toReduce;
                }
                else
                {
                    item.Quality = 0;
                }                
            }
            else
            {
                item.Quality = item.Quality - reducer;
            }
        }
        private void UpdateAgedBrie(Item item)
        {
            if (item.Quality < Helper.MaxQuality)
            {
                item.Quality = item.Quality + 1;
            }
        }

        private void UpdateBackstagePassese(Item item)
        {
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
            else if (item.Quality > Helper.MaxQuality - 1)
            {
                return;
            }
            else if (item.SellIn < 6)
            {
                item.Quality = GetQuality(item.Quality, 2);                
            }
            else if (item.SellIn < 11)
            {
                item.Quality = GetQuality(item.Quality, 1);               
            }
            /* I don't see the requirement of this part in the task. 
            else
            {
                item.Quality = item.Quality + 1;
            }*/
        }

        private int GetQuality(int currentQuality, int increaser)
        {
            if (currentQuality < Helper.MaxQuality - increaser)
            {
                return currentQuality + increaser + 1;
            }
            else
            {
                return Helper.MaxQuality;
            }
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                switch (Items[i].Name)
                {
                    case "Sulfuras, Hand of Ragnaros":
                        continue;
                    case "Aged Brie":
                        UpdateAgedBrie(Items[i]);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        UpdateBackstagePassese(Items[i]);
                        break;
                    case "Conjured Mana Cake":
                        UpdateProduct(Items[i], 2);
                        break;
                    default:
                        UpdateProduct(Items[i], 1);
                        break;
                }

                Items[i].SellIn = Items[i].SellIn - 1;
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }
}
