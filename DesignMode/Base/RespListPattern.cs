using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    public class Responce
    {
        public int weight;
        public string param;
    }

    public abstract class IRepNode
    {
        private IRepNode next;
        private int weight;
        public IRepNode(int weight, IRepNode next)
        {
            this.weight = weight;
            this.next = next;
        }

        //模板方法定义处理流程
        public void Excute(Responce responce)
        {
            if (weight >= responce.weight)
                Call(responce.param);
            else if (next != null)
                next.Excute(responce);
            else
                Console.WriteLine("nobody responce");
        }

        public abstract void Call(string param);
    }

    public class BigBoy : IRepNode
    {
        public BigBoy(int weight, IRepNode next) : base(weight, next){}
        public override void Call(string param)
        {
            Console.WriteLine("this is bigboy responce " + param);
        }
    }

    public class LittleBoy : IRepNode
    {
        public LittleBoy(int weight, IRepNode next) : base(weight, next) { }
        public override void Call(string param)
        {
            Console.WriteLine("this is littleboy responce " + param);
        }
    }

    public class RespListMgr
    {
        IRepNode bigboy;
        IRepNode littleboy;
        public RespListMgr()
        {
            //构造责任链
            bigboy    = new BigBoy(100, null);
            littleboy = new LittleBoy(0, bigboy);
        }
        
        public void ExcuteResp(Responce responce)
        {
            // 返回权限最小节点，优先处理请求
            littleboy.Excute(responce);
        }

    }

    /*
     * 责任链模式:将功能执行者按权限排列为一条链表，最低权限节点优先处理请求，若当前节点权限不足则向上传递请求
     * 分离请求和执行者的依赖
     */
    public class RespListPattern
    {
        /*
        static void Main(string[] args)
        {
            RespListMgr mgr = new RespListMgr();

            Responce responce = new Responce();
            responce.weight = 80;
            responce.param = "request";
            mgr.ExcuteResp(responce);

            Console.ReadLine();
        }
        */
    }
}
