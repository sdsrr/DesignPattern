using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    //目标接口
    public interface ITarget{void Call();}

    //源对象
    public class Source
    {
        public void Function() { Console.WriteLine("this is target"); }
    }

    //类适配器
    public class ClassAdpter : Source,ITarget
    {
        //将源对象function转化为目标的call
        public void Call() { Function(); }
    }

    //对象适配器
    public class CohesionAdpter : ITarget
    {
        private Source source;
        public CohesionAdpter(Source src) { source = src; }
        public void Call() { source.Function(); }
    }

    //适配器模式：补救模式，源对象接口与目标对象需求接口不一致时增加中间类转化接口,分类类适配器(继承)与对象适配器(内聚)
    public class AdpterPattern
    {
        /*
        static void Main(string[] args)
        {
            ITarget adpter01 = new ClassAdpter();
            adpter01.Call();

            ITarget adpter02 = new CohesionAdpter(new Source());
            adpter02.Call();

            Console.ReadLine();
        }
        */
    }
}
