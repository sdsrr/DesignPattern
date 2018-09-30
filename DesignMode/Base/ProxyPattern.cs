using System;
using System.Collections.Generic;

namespace DesignMode
{
    public interface ITalk
    {
        void Talk();
    }

    public class TalkDog : ITalk
    {
        public void Talk()
        {
            Console.WriteLine("the dog is talk");
        }
    }

    public interface IProxy
    {
        void Call();
    }

    //简单代理
    public class SimpleProxy : ITalk, IProxy
    {
        ITalk relObject;
        public SimpleProxy(ITalk relObject) { this.relObject = relObject; }
        public void Call() { Console.WriteLine("call function "); }

        public void Talk()
        {
            //调用代理自身相关功能
            Call();
            //调用真实对象对应方法
            relObject.Talk();
        }
    }

    //复杂代理:简单代理只能针对特定接口如italk,复杂代理不限制接口类型
    public class ProxyInterceptor 
    {

    }


    // 封装对对象的访问，增加权限控制等额外功能
    public class ProxyPattern
    {
        /*
        static void Main(string[] args)
        {
            ITalk proxy = new SimpleProxy(new TalkDog());
            proxy.Talk();
            Console.ReadLine();
        }
        */
    }
}
