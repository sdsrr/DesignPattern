using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    public interface Produce
    {
        void Call();
    }

    public class Produce01 : Produce
    {
        public void Call() { Console.WriteLine("this is produce01"); }
    }

    public class Produce02 : Produce
    {
        public void Call() { Console.WriteLine("this is produce02"); }
    }

    public class Produce03 : Produce
    {
        public void Call() { Console.WriteLine("this is produce03"); }
    }
    //1.简单工厂
    public class SimpleFactory
    {
        //创建接口使用静态函数，减少创建Factory对象过程
        public static Produce Create<T>() where T :Produce, new()
        {
            T produece = new T();
            return produece;
        }

        public static Produce Create(Type type)
        {
            if (type == typeof(Produce01))
                return new Produce01();
            else if (type == typeof(Produce02))
                return new Produce02();
            else if (type == typeof(Produce03))
                return new Produce03();
            return null;
        }
    }


    //2.复杂工厂，每个对象创建过程复杂，用单独的工厂封装
    public abstract class Factory
    {
        public abstract Produce Create();
    }
    public class Pro01Factory : Factory
    {
        public override Produce Create()
        {
            //复杂创建
            return new Produce01();
        }
    }
    public class Pro02Factory : Factory
    {
        public override Produce Create()
        {
            //复杂创建
            return new Produce02();
        }
    }
    public class Pro03Factory : Factory
    {
        public override Produce Create()
        {
            //复杂创建
            return new Produce03();
        }
    }


    //工厂方法模式：提供创建对象的统一接口
    class FactoryPattern
    {
        /*
        static void Main(string[] args)
        {
            Produce pro01 = SimpleFactory.Create<Produce01>();
            pro01.Call();
            Produce pro02 = SimpleFactory.Create<Produce02>();
            pro02.Call();
            Produce pro03 = SimpleFactory.Create<Produce03>();
            pro03.Call();


            Produce pro11 = new Pro01Factory().Create();
            pro11.Call();
            Produce pro12 = new Pro02Factory().Create();
            pro12.Call();
            Produce pro13 = new Pro03Factory().Create();
            pro13.Call();

            Console.ReadLine();
        }
        */
    }
}
