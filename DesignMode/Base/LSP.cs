using System;
using System.Collections.Generic;

namespace DesignMode
{

    /*
        里氏替换：使用父类的地方都可以替换为子类，但使用子类的地方不一定可以替换为父类
        1.子类可以有自己的特有方法
        2.子类可以实现父类抽象方法，但不能覆盖父类方法(关键)
        3.子类实现父类抽象方法时，函数参数类型应该为父类函数参数类型或其父类
        4.子类实现父类抽象方法时，函数返回值类型应该为父类函数参数类型或其子类
        总结：子类继承父类时，尽量不修改父类功能，维持原父类方法有效(检验方法就是，原来使用父类的地方替换为子类是否功能改变)
    */

    public class ParentParam { }
    public class ChildParam :ParentParam { }
    public class GrandChildParam : ChildParam { }

    public class Parent
    {
        public void CallOverlap()
        {
            Console.WriteLine("this is parent overlap");
        }

        public void Call(ChildParam param) { }
        public ParentParam Call() { return default(ParentParam); }
    }

    public class Child : Parent
    {
        //覆盖父类方法，可能导致父类功能改变
        public new void CallOverlap() { Console.WriteLine("this is child overlap"); }

        //子类自定义方法
        public void SelfCall() { }

        //参数类型比父类宽松，是重载而不是重写
        public void Call(ParentParam param) { }

        //返回类型比父类严格
        public new GrandChildParam Call() { return default(GrandChildParam); }

    }

    class LPS
    {
        public static void Call(Parent parent) { parent.CallOverlap(); }
        public static void Call(Child child) { child.CallOverlap(); }
        /*
        static void Main(string[] args)
        {
            Call(new Parent());
            //使用父类的地方替换为子类功能发生了变换，违背里氏替换
            Console.WriteLine("use child replace parent");
            Call(new Child());

            Console.ReadLine();
        }
        */
    }
}
