using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    public class Email
    {
        //初始创建内部状态，后面不再修改
        public Email(string sub) { subject = sub; }
        //内部状态
        private string subject;

        //外部状态
        public string context;
        public string receiver;

        public override string ToString() { return "sub: " + subject + " cxt: " + context + " rev: " + receiver; }
    }

    public class EmailFactory
    {
        //email.subject作为key
        private Dictionary<string, Email> pools = new Dictionary<string, Email>();
        public Email CreateEmail(string sub, string cxt, string rev)
        {
            Email email = null;
            pools.TryGetValue(sub, out email);
            if (email == null)
            {
                email = new Email(sub);
                pools[sub] = email;
            }
            //修改外部状态
            email.receiver = rev;
            email.context = cxt;
            return email;
        }
    }

    //享元模式：将对象成员分为共享成员(内部状态)和非共享成员(外部状态)，使用缓存池缓存对象，实现对象共享
    class FlyWeightPattern
    {
        /*
        static void Main(string[] args)
        {
            //实际引用的一个email
            EmailFactory factory = new EmailFactory();
            Email email01 = factory.CreateEmail("ceshi01", "内容111", "zhangsan");
            Email email02 = factory.CreateEmail("ceshi01", "内容222", "lishi");
            Console.WriteLine(email01.ToString());
            Console.WriteLine(email02.ToString());
            Console.ReadLine();
        }
        */
    }
}
