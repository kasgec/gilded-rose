
namespace GildedRose.Console
{
    public static class Helper
    {
        public static int MaxQuality { get; set; } = 50;
        public static void ValidateItem(this Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                if (item.Quality != 80)
                    item.Quality = 80;

                if (item.SellIn != 0)
                    item.SellIn = 0;               
            }
            else if (item.Quality < 0)
            {
                item.Quality = 0;
            }
            else if (item.Quality > MaxQuality)
            {
                item.Quality = MaxQuality;
            }
        }
    }
}
