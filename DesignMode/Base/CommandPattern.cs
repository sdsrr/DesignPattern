using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    // 执行者work有具体功能接口
    public class Worker
    {
        public void Call01() { Console.WriteLine("this is worker call01 "); }
        public void Call02() { Console.WriteLine("this is worker call02 "); }
    }
    public interface ICommand
    {
        void Excute();
    }

    // 具体命令依赖具体的执行者worker，调用worker实现具体功能
    public class ACommand : ICommand
    {
        Worker worker = new Worker();
        public void Excute()
        {
            worker.Call01();
        }
    }

    public class BCommand : ICommand
    {
        Worker worker = new Worker();
        public void Excute()
        {
            worker.Call02();
        }
    }

    // 调用者维护管理cmd，并调用执行对应方法
    public class Invoker
    {
        ICommand command;
        public void SetCmd(ICommand cmd) { command = cmd; }
        public void Excute() { command.Excute(); }
    }

    public class CommandPattern
    {
        /*
        static void Main(string[] args)
        {
            // client层只依赖具体cmd，创建并传递给调用者执行
            // client不再依赖具体worker，或关心具体的调用过程
            Invoker invoker = new Invoker();
            ACommand cmd01 = new ACommand();
            invoker.SetCmd(cmd01);
            invoker.Excute();

            BCommand cmd02 = new BCommand();
            invoker.SetCmd(cmd02);
            invoker.Excute();
            Console.ReadLine();
        }
        */
    }
}
