using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class QualityUpdatingStrategyFactory
    {
        readonly Dictionary<string,Func<IQualityUpdatingStrategy>>  strategies = 
            new Dictionary<string, Func<IQualityUpdatingStrategy>>()
            {
                { ProductNameConstants.AgedBrie,()=>new AgedBrieStrategy() },
                { ProductNameConstants.BackstagePassesToATafkal80EtcConcert,()=>new BackStagePassesStrategy() },
                { ProductNameConstants.SulfurasHandOfRagnaros,()=>new SulfurasHandOfRagnarosStrategy() }
            };
        public IQualityUpdatingStrategy Create(ItemWrapper item)
        {
            if (strategies.ContainsKey(item.Name))
            {
                return strategies[item.Name]();
            }
            return new DefaultQualityUpdatingStrategy();
        }
    }

    internal class SulfurasHandOfRagnarosStrategy : IQualityUpdatingStrategy
    {
        public ItemWrapper UpdateQuality(ItemWrapper item)
        {
            return item;
        }
    }

    internal class BackStagePassesStrategy : IQualityUpdatingStrategy
    {
        public ItemWrapper UpdateQuality(ItemWrapper item)
        {
            item.Quality = item.Quality + 1;
            if (item.SellIn < 11)
            {
                item.Quality = item.Quality + 1;
            }

            if (item.SellIn < 6)
            {
                item.Quality = item.Quality + 1;
            }

            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
            item.SellIn -= 1;
            return item;
        }

   
    }

    internal class AgedBrieStrategy : IQualityUpdatingStrategy
    {
        public ItemWrapper UpdateQuality(ItemWrapper item)
        {
            item.Quality = item.Quality + 1;
            item.SellIn -= 1;
            if (item.SellIn < 0)
            {
                item.Quality = item.Quality + 1;
            }
            return item;
        }
    }
}