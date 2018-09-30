using System;
using System.Collections.Generic;


namespace Project
{

    //参数对象，解析输入字符创
    public class Param
    {
        private static Dictionary<string, AbstractCommand> commands = new Dictionary<string, AbstractCommand>
        {
            {"ls", new LSCommand()},
            {"jb", new JBCommand()},
        };

        public string command;
        public string type;
        public string param; 
        public Param(string input)
        {
            string[] param = input.Split(' ');
            this.command = param[0];
            this.type = param[1];
            this.param = param[2];
        }

        public void Excute()
        {
            AbstractCommand commandCls = commands[command];
            commandCls.Excute(this);
        }
    }

    //抽象责任链节点
    public abstract class AbstractResp
    {
        //下一个处理节点
        AbstractResp next;
        public AbstractResp(AbstractResp next) { this.next = next; }

        //模板方法定义算法，当前节点处理或下一节点处理
        public void Run(Param param)
        {
            if (CheckExcute(param))
                Excute(param);
            else if(next != null)
                next.Run(param);
        }
        protected virtual bool CheckExcute(Param param) { return false; }
        protected virtual void Excute(Param param) { }
    }

    //具体责任链节点
    public class Ls_A_Resp : AbstractResp
    {
        public Ls_A_Resp(AbstractResp next) : base(next) { }
        protected override bool CheckExcute(Param param) { return param.type == "a"; }
        protected override void Excute(Param param) {Console.WriteLine("excute ls a commond!  param : " + param.param);}
    }

    public class Ls_B_Resp : AbstractResp
    {
        public Ls_B_Resp(AbstractResp next) : base(next) { }
        protected override bool CheckExcute(Param param) { return param.type == "b"; }
        protected override void Excute(Param param) {Console.WriteLine("excute ls b commond!  param : " + param.param);}
    }

    public class Ls_C_Resp : AbstractResp
    {
        public Ls_C_Resp(AbstractResp next) : base(next) { }
        protected override bool CheckExcute(Param param) { return param.type == "c"; }
        protected override void Excute(Param param) { Console.WriteLine("excute ls c commond!  param : " + param.param); }
    }

    //命令模式封装构建责任链
    public abstract class AbstractCommand
    {
        protected AbstractResp head;
        public void Excute(Param param) { head.Run(param); }
    }

    public class LSCommand : AbstractCommand
    {
        public LSCommand()
        {
            AbstractResp lsc = new Ls_C_Resp(null);
            AbstractResp lsb = new Ls_B_Resp(lsc);
            head = new Ls_A_Resp(lsb);
        }
    }

    public class JBCommand : AbstractCommand
    {
        //这里为了简化，使用相同的责任链
        public JBCommand()
        {
            AbstractResp lsc = new Ls_C_Resp(null);
            AbstractResp lsb = new Ls_B_Resp(lsc);
            head = new Ls_A_Resp(lsb);
        }
    }

    /*
     * 命令模式+责任链+模板方法 处理命令解析
     * 责任链模式：处理具体命令
     * 命令模式：封装构建责任链，使用责任链处理
     * 模板方法：定义责任链中处理命令的基本算法
     * 上述例子只定义了ls命令的责任链和命令类，可以横向扩充其他命令的责任链，及对应命令类
     */
    public class CommondWithResp
    {
        /*
        static void Main(string[] args)
        {
            Param param01 = new Param("ls a cehis01");
            param01.Excute();

            Param param02 = new Param("jb b ceshi02");
            param02.Excute();
            Console.ReadLine();
        }
        */
    }
}
