using System;
using System.Collections.Generic;


namespace DesignMode
{
    public enum Sex
    {
        Man,
        Women,
    }

    public class VisitPattern
    {
        //访问者接口，针对具体类的不同访问方法
        public interface Visitor
        {
            void Visit(TeacherData data);
            void Visit(StuData data);
        }

        //具体访问者--统计总年龄
        public class AgeVisitor : Visitor
        {
            private int total = 0;
            public int GetTotal() { return total; }
            //通过重载来处理不同的数据
            public void Visit(StuData data){total += data.age * 3;}
            public void Visit(TeacherData data){total += data.age * 2;}
        }
        //计算女生数量
        public class WomenVisitor : Visitor
        {
            private int total = 0;
            public int GetTotal() { return total; }
            public void Visit(StuData data)
            {
                //通过数据类接口获取数据
                if (data.sex == Sex.Women)
                    total++;
            }

            public void Visit(TeacherData data)
            {
                if (data.sex == Sex.Women)
                    total++;
            }
        }

        public interface IVisit
        {
            void Visit(Visitor visitor);
        }

        //数据类，提供公共的访问接口
        public class TeacherData : IVisit
        {
            public string name;
            public Sex sex;
            public int age;

            public TeacherData(string name, Sex sex, int age)
            {
                this.name = name;
                this.sex = sex;
                this.age = age;
            }

            public void Visit(Visitor visitor)
            {
                visitor.Visit(this);
            }
        }

        public class StuData : IVisit
        {
            public string name;
            public Sex sex;
            public int age;

            public StuData(string name, Sex sex, int age)
            {
                this.name = name;
                this.sex = sex;
                this.age = age;
            }

            public void Visit(Visitor visitor)
            {
                visitor.Visit(this);
            }
        }
        /*
        //访问者模式：将数据与数据的业务逻辑进行分离，访问类的访问方法依赖具体类，实现不同逻辑
        static void Main(string[] args)
        {
            List<IVisit> list = new List<IVisit>();
            list.Add(new TeacherData("tea01", Sex.Women, 20));
            list.Add(new TeacherData("tea02", Sex.Man, 30));
            list.Add(new TeacherData("tea03", Sex.Man, 40));
            list.Add(new TeacherData("tea04", Sex.Women, 50));

            list.Add(new StuData("stu01", Sex.Women, 11));
            list.Add(new StuData("stu02", Sex.Women, 12));
            list.Add(new StuData("stu03", Sex.Women, 13));
            list.Add(new StuData("stu04", Sex.Women, 14));

            AgeVisitor ageVisitor = new AgeVisitor();
            WomenVisitor womenVisitor = new WomenVisitor();
            foreach (IVisit member in list)
            {
                //list中有两种具体数据类，相同访问者对象进行统计，类似策略模式传入具体业务逻辑的算法，相比策略模式访问者需要传入访问对象作为参数
                member.Visit(ageVisitor);
                member.Visit(womenVisitor);
            }

            Console.WriteLine("total age is " + ageVisitor.GetTotal());
            Console.WriteLine("women num is " + womenVisitor.GetTotal());

            Console.ReadLine();
        }
        */
    }
}
