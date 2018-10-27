using System;
using System.Collections.Generic;


namespace Complex
{
    public class SingleManager<T> where T : new()
    {
        public static T GetInstance()
        {
            if (instance == null)
                instance = new T();
            return instance;
        }
        private static T instance;
    }

    public class SimpleClass
    {
        public SimpleClass() { }
        public void Call() { Console.WriteLine("single pattern..."); }
    }

    //相比使用传统的继承SingleManager实现单例，这里将单例封装到mgr通过接口获取单例接口
    //问题是无法保证SimpleClass唯一，因为外部也可以使用new创建
    public class SinglePattern
    {
        /*
        static void Main(string[] args)
        {
            SimpleClass instance = SingleManager<SimpleClass>.GetInstance();
            instance.Call();
            Console.ReadLine();
        }
        */
    }
}
