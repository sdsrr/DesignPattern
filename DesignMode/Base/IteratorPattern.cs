using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    public interface AbstractGameObject{void Call();}

    public class GameObject : AbstractGameObject
    {
        private int param;
        public GameObject(int p) { param = p; }
        public void Call() { Console.WriteLine("this is " + param); }

        
    }

    //对象管理器，类似容器类
    public class GameObjectCentext
    {
        private List<AbstractGameObject> list = new List<AbstractGameObject>();
        
        //返回迭代器接口
        public IIterator GetIterator()
        {
            IIterator iterator = new Iterator(list.ToArray());
            return iterator;
        }

        public void Add(int param)
        {
            list.Add(new GameObject(param));
        }
    }

    // 迭代器公共接口
    public interface IIterator
    {
        bool HasNext();
        AbstractGameObject Current();
    }

    public class Iterator : IIterator
    {
        //迭代器维护数据和当前访问下标
        private AbstractGameObject[] list;
        private int index = 0;
        public Iterator(AbstractGameObject[] list) { this.list = list; }

        public bool HasNext()
        {
            return index >= 0 && index < list.Length;  
        }

        public AbstractGameObject Current()
        {
            int i = Math.Min(index++, list.Length - 1);
            return list[i];
        }
    }

    //迭代器模式:将容器的访问控制进行封装
    public class IteratorPattern
    {
        /*
        static void Main(string[] args)
        {
            GameObjectCentext context = new GameObjectCentext();
            context.Add(1);
            context.Add(2);
            context.Add(3);

            //获取迭代器进行迭代
            IIterator iterator = context.GetIterator();
            while(iterator.HasNext())
            {
                AbstractGameObject gameobj = iterator.Current();
                gameobj.Call();
            }
            Console.ReadLine();
        }
        */
    }
}
