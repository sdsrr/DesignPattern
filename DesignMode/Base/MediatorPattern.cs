using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    public abstract class Model
    {
        //功能模块只依赖中介对象
        protected Mediator mdeiator;
        public Model(Mediator med) { mdeiator = med; }
    }

    public class Model01: Model
    {
        public Model01(Mediator med) : base(med) { }
        // 与其他模块有交互部分在中介者中实现
        public void Call01()
        {
            mdeiator.Call("call01");
            Console.WriteLine("this is model01 1");
        }
        public void Call02()
        {
            mdeiator.Call("call02");
            Console.WriteLine("this is model01 2");
        }
    }
    public class Model02 : Model
    {
        public Model02(Mediator med) : base(med) { }
        public void Call01() { Console.WriteLine("this is model02 1"); }
        public void Call02() { Console.WriteLine("this is model02 2"); }
    }
    public class Model03 : Model
    {
        public Model03(Mediator med) : base(med) { }
        public void Call01() { Console.WriteLine("this is model03 1"); }
        public void Call02() { Console.WriteLine("this is model03 1"); }
    }
    public class Mediator
    {
        private Model01 model01;
        private Model02 model02;
        private Model03 model03;

        public void SetModel(Model01 med01, Model02 med02, Model03 med03)
        {
            model01 = med01;
            model02 = med02;
            model03 = med03;
        }

        // 提供给模块接口
        public void Call(string fn)
        {
            if (fn == "call01")
                Call01();
            else if (fn == "call02")
                Call02();
        }

        //内部复杂的相互调用
        private void Call01()
        {
            Console.WriteLine("call other model  start");
            model02.Call01();
            model03.Call01();
            Console.WriteLine("call other model end");
        }
        private void Call02()
        {
            model02.Call02();
            model03.Call02();
        }

    }

    //中介者模式:将网状依赖关系改为星型依赖关系
    public class MediatorPattern
    {
        /*
        static void Main(string[] args)
        {
            Mediator med = new Mediator();
            Model01 med01 = new Model01(med);
            Model02 med02 = new Model02(med);
            Model03 med03 = new Model03(med);
            med.SetModel(med01, med02, med03);
            med01.Call01();
            Console.ReadLine();
        }
        */
    }
}
