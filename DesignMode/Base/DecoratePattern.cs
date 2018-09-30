using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    public interface ICommon
    {
        void Excute();
    }

    public class RealObject : ICommon
    {
        public void Excute(){ Console.WriteLine("this is real excute"); }
    }

    public abstract class Decorat : ICommon
    {
        protected ICommon target;
        public Decorat(ICommon target) { this.target = target; }
        public abstract void Excute();
    }

    public class Decorate01 : Decorat
    {
        public Decorate01(ICommon target) : base(target) { }
        public override void Excute()
        {
            // 扩展功能并调用原目标的方法
            Console.WriteLine("this is decorate 01");
            target.Excute();
        }
    }

    public class Decorate02 : Decorat
    {
        public Decorate02(ICommon target) : base(target) { }
        public override void Excute()
        {
            // 扩展功能并调用原目标的方法
            Console.WriteLine("this is decorate 02");
            target.Excute();
        }
    }

    //装饰者模式：特殊的代理模式，通过聚合扩展类的功能
    public class DecoratePattern
    {
        /*
        static void Main(string[] args)
        {
            RealObject relObject = new RealObject();
            // 对obj进行两次装饰
            Decorate01 decorate01 = new Decorate01(relObject);
            Decorate02 decorate02 = new Decorate02(decorate01);
            decorate02.Excute();
            Console.WriteLine();

            //对obj进行一次装饰
            Decorate02 decorate03 = new Decorate02(relObject);
            decorate03.Excute();
            Console.ReadLine();
        }
        */
    }
}
