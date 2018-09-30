using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    public interface IStrategy
    {
        void Eecute();
    }

    public class AStrategy : IStrategy
    {
        public void Eecute(){Console.WriteLine("this is AStrategy");}
    }

    public class BStrategy : IStrategy
    {
        public void Eecute() { Console.WriteLine("this is BStrategy"); }
    }

    //对策略的简单封装
    public class StrategyContext
    {
        private IStrategy strategy;
        public void SetStrategy(IStrategy strategy) { this.strategy = strategy; }
        public void Excute() { strategy.Eecute(); }
    }

    //策略模式：将算法的具体实现封装起来，上层可决定具体的策略或替换策略
    public class StrategyPattern
    {
        /*
        static void Main(string[] args)
        {
            StrategyContext context = new StrategyContext();
            context.SetStrategy(new AStrategy());
            context.Excute();
            context.SetStrategy(new BStrategy());
            context.Excute();
            Console.ReadLine();
        }
        */
    }
}
