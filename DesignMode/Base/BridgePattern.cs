using System;
using System.Collections.Generic;


namespace DesignMode
{
    //实现类的基类
    public abstract class ConcreteCls
    {
        public abstract void Call();
    }

    //实现类独立变化
    public class Concrete01 : ConcreteCls
    {
        public override void Call() {Console.WriteLine("this is detail class01");}
    }
    public class Concrete02 : ConcreteCls
    {
        public override void Call() { Console.WriteLine("this is detail class02"); }
    }

    //抽象类独立基类
    public abstract class AbstractCls
    {
        public ConcreteCls concrete;
        public AbstractCls(ConcreteCls p) { concrete = p; }
        //接口如同桥梁，可以访问实现类方法
        public void Call() { concrete.Call(); }
    }
    //抽象类独立变化
    public class Abstract01 : AbstractCls
    {
        public int param;
        public Abstract01(ConcreteCls p) : base(p){}

        public void MyCall() { }
    }


    //桥接模式：解耦抽象与实现，使两者可以独立变化，
    public class BridgePattern
    {
        /*
        static void Main(string[] args)
        {
            //1.实现类ConcreteCls和接口类AbstractCls都可独立变化
            //2.接口类引用实现类，并提供外界调用的接口，相比代继承接口类的粒度更小(无论实现类多大，接口类本身大小可以控制)
            //且对实现类依赖更小，封装变化
            
            Abstract01 abs = new Abstract01(new Concrete02());
            abs.Call();
            Console.ReadLine();
        }
        */
    }
}
