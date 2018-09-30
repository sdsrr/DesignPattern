using System;
using System.Collections.Generic;

namespace DesignMode
{
    public interface Component
    {
        void Visit();
    }

    public class Leaf : Component
    {
        private string name;
        public Leaf(string val) { this.name = val; }
        public void Visit()
        {
            Console.WriteLine("this is " + name);
        }
    }

    public class Branch : Component
    {
        private string name;
        //父节点与子节点
        private Component parent;
        private List<Component> childs;
        public Branch(string val, List<Component> childs)
        {
            this.name = val;
            this.childs = new List<Component>(childs);
        }
        public void Visit()
        {
            //先输出自身再输出child
            Console.WriteLine("this is " + name);
            for (int i = 0; i < childs.Count; i++)
            {
                Component cmp = childs[i];
                cmp.Visit();
            }  
        }
    }

    //组合模式：构建树形关系图，每个节点的访问具有一致性
    public class ComponentPattern
    {
        /*
        static void Main(string[] args)
        {
            Component leafA = new Leaf("zhang san");
            Component leafB = new Leaf("li shi");
            Component leafC = new Leaf("wang wu");
            List<Component> list = new List<Component>();
            list.Add(leafA);
            list.Add(leafB);
            
            Component branch = new Branch("branch", list);
            List<Component> list2 = new List<Component>();
            list2.Add(leafC);
            list2.Add(branch);

            Component root = new Branch("root", list2);
            root.Visit();
            Console.ReadLine();
        }
        */
    }
}
