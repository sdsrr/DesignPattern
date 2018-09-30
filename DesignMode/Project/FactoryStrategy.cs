using System;
using System.Collections.Generic;


namespace Project
{
    public enum GoodsType
    {
        Noraml,
        HalfPrice,
        Max,
    }
    //账户金额类
    public class Card
    {
        public int toal = 100;
    }
    //商品类
    public class Goods
    {
        public int price;
        public GoodsType type;

        public Goods(int price, GoodsType type)
        {
            this.price = price;
            this.type = type;
        }
    }

    //扣款抽象类
    public abstract class AbsGoodsStrategy
    {
        public abstract void Sell(Card card, Goods goods);
    }

    public class NormalGoodsStrategy : AbsGoodsStrategy
    {
        public override void Sell(Card card, Goods goods)
        {
            card.toal -= goods.price;
            Console.WriteLine("normal price!  card total" + card.toal);
        }
    }

    public class HalfGoodsStrategy : AbsGoodsStrategy
    {
        public override void Sell(Card card, Goods goods)
        {
            card.toal -= goods.price/2;
            Console.WriteLine("price price!  card total" + card.toal);
        }
    }

    //工厂方法创建封装创建具体策略
    public class GoodsStrategyFactory
    {
        private Dictionary<GoodsType, AbsGoodsStrategy> list = new Dictionary<GoodsType, AbsGoodsStrategy>
        {
            { GoodsType.Noraml, new NormalGoodsStrategy() },
            { GoodsType.HalfPrice, new HalfGoodsStrategy()},
        };

        public static AbsGoodsStrategy CreateStategy(GoodsType type)
        {
            switch(type)
            {
                case GoodsType.Noraml:
                    return new NormalGoodsStrategy();
                case GoodsType.HalfPrice:
                    return new HalfGoodsStrategy();
            }
            return null;

            //或者return list[type];
        }
    }

    //门面封装提供扣款接口
    public class GoodsFacade
    {
        public void Sell(Card card, Goods good)
        {
            AbsGoodsStrategy strategy = GoodsStrategyFactory.CreateStategy(good.type);
            strategy.Sell(card, good);
        }
    }

    /*
     * 模拟消费扣款，消费有多种方式
     * 策略模式 + 工厂模式 + 门面模式 
     * 策略模式：封装不同扣款策略
     * 工厂模式：封装创建具体策略
     * 门面模式：封装扣款细节，对外提供简单接口
     */
    public class FactoryStrategy
    {
        /*
        static void Main(string[] args)
        {
            Card card = new Card();
            GoodsFacade facade = new GoodsFacade();
            Goods good1 = new Goods(10, GoodsType.Noraml);
            Goods good2 = new Goods(10, GoodsType.HalfPrice);
            facade.Sell(card, good1);
            facade.Sell(card, good2);
            Console.ReadLine();
        }
        */
    }
}
