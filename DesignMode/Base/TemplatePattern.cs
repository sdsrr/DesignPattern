using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    public abstract class TemplateParent
    {
        //抽象方法protected禁止外部调用
        protected abstract void Call01();
        protected abstract void Call02();
        protected abstract void Call03();

        //钩子方法
        protected virtual bool IsExcute() { return true; }
        //子类定义函数框架
        public void CallTemplate()
        {
            Call01();
            Call02();

            if (IsExcute())
                Call03();
        }
    }

    public class TemplateChild1 : TemplateParent
    {
        protected override void Call01() { Console.WriteLine("this is child01 call01"); }
        protected override void Call02() { Console.WriteLine("this is child01 call02"); }
        protected override void Call03() { Console.WriteLine("this is child01 call03"); }
        protected override bool IsExcute() { return false; }
    }

    public class TemplateChild2 : TemplateParent
    {
        protected override void Call01() { Console.WriteLine("this is child02 call01"); }
        protected override void Call02() { Console.WriteLine("this is child02 call02"); }
        protected override void Call03() { Console.WriteLine("this is child02 call03"); }
        protected override bool IsExcute() { return true; }
    }

    //模板方法模式：父类定义算法框架(函数调用流程)，子类负责抽象方法具体实现
    public class TemplatePattern
    {
        /*
        static void Main(string[] args)
        {
            TemplateChild1 child01 = new TemplateChild1();
            child01.CallTemplate();

            Console.WriteLine();
            TemplateChild2 child02 = new TemplateChild2();
            child02.CallTemplate();
            Console.ReadLine();
        }
        */
    }
}
