using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    public class AbsProduce
    {
        public string name;
        public int price;
        public void Call() { Console.WriteLine("name is " + name + " price is " + price); }
    }

    public abstract class Builder
    {
        //创建接口，复杂的创建流程
        public abstract AbsProduce Create(int price);
    }

    public class Builder01 : Builder
    {
        public override AbsProduce Create(int price)
        {
            AbsProduce pro = new AbsProduce();
            pro.name = "produce01";
            pro.price = price;
            return pro;
        }
    }

    public class Builder02 : Builder
    {
        public override AbsProduce Create(int price)
        {
            AbsProduce pro = new AbsProduce();
            pro.name = "produce02";
            pro.price = price;
            return pro;
        }
    }

    public class Director
    {
        //对创建工厂的管理
        private Builder01 builder01 = new Builder01();
        private Builder02 builder02 = new Builder02();

        //传递参数
        public AbsProduce Create01_1() { return builder01.Create(10); }
        public AbsProduce Create01_2() { return builder01.Create(20); }
        public AbsProduce Create02_1() { return builder02.Create(1); }
        public AbsProduce Create02_2() { return builder02.Create(1); }
    }

    //建造者模式：封装复杂对象创建过程
    public class CreatorPattern
    {
        /*
        static void Main(string[] args)
        {
            Director director = new Director();
            AbsProduce pro01_1 = director.Create01_1();
            AbsProduce pro01_2 = director.Create01_2();
            pro01_1.Call();
            pro01_2.Call();
            Console.ReadLine();
        }
        */
    }
}
