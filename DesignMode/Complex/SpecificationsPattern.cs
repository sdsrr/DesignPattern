using System;
using System.Collections.Generic;


namespace ComplexDesignMode
{
    public class SpecParam
    {
        public string name;
        public int age;
        public SpecParam(int val, string name) { this.age = val; this.name = name; }
        public void Show() { Console.WriteLine("i'm " + name + " age " + age); }
    }

    public abstract class AbsSpec
    {
        public abstract bool Check(SpecParam param);

        ///因为组合节点比较固定，可以父类依赖子类
        public AbsSpec And(AbsSpec right) { return new AndSpec(this, right); }
        public AbsSpec Or(AbsSpec right) { return new OrSpec(this, right); }
    }

    //组合规则实现组合对象功能
    public class AndSpec : AbsSpec
    {
        private AbsSpec left;
        private AbsSpec right;
        public AndSpec(AbsSpec l, AbsSpec r)
        {
            left = l;
            right = r;
        }

        public override bool Check(SpecParam param)
        {
            return left.Check(param) && right.Check(param);
        }
    }

    public class OrSpec : AbsSpec
    {
        private AbsSpec left;
        private AbsSpec right;
        public OrSpec(AbsSpec l, AbsSpec r)
        {
            left = l;
            right = r;
        }

        public override bool Check(SpecParam param)
        {
            return left.Check(param) || right.Check(param);
        }
    }

    //业务规则实现业务逻辑
    public class MoreThan : AbsSpec
    {
        private int val = 0;
        public MoreThan(int v) { this.val = v; }
        public override bool Check(SpecParam param)
        {
            return param.age > val;
        }
    }

    public class LessThan : AbsSpec
    {
        private int val;
        public LessThan(int v) { this.val = v; }
        public override bool Check(SpecParam param)
        {
            return param.age < val;
        }
    }

    //规格书：特殊的组合模式组织结构+策略模式的使用方式，实现简单的连缀运算，分为业务规格和组合规格
    public class SpecificationsPattern
    {
        /*
        static void Main(string[] args)
        {
            List<SpecParam> list = new List<SpecParam>
            {
                new SpecParam(10, "ceshi01"),
                new SpecParam(20, "ceshi02"),
                new SpecParam(30, "ceshi03"),
                new SpecParam(40, "ceshi04"),
            };
            AbsSpec check1 = new MoreThan(10).And(new LessThan(40));
            AbsSpec check2 = new MoreThan(10).And(new LessThan(40)).Or(new LessThan(100));
            foreach(SpecParam child in list)
            {
                if (check1.Check(child))
                    child.Show();
            }
            Console.WriteLine("--------------------------");
            foreach (SpecParam child in list)
            {
                if (check2.Check(child))
                    child.Show();
            }
            Console.ReadLine();
        }
        */
    }
}
