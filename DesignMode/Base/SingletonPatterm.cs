using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    public class Emperor
    {
        //私有构造，禁止外面创建对象
        private Emperor() { }

        //懒汉式，多线程时有问题
        private static Emperor instance;
        //对面获取对象接口
        public static Emperor GetInstance()
        {
            if (instance == null)
                instance = new Emperor();
            return instance;
        }

        //饿汉式
        private static Emperor instance2 = new Emperor();
        public static Emperor GetInstance2() { return instance2; }

        public void Call()
        {
            Console.WriteLine("this is emperot");
        }
    }

    public class Singleton<T> where T:new()
    {
        private static T instance;
        public static T GetInstance()
        {
            if (instance == null)
            {
                instance = new T();
                Singleton<T> _ins = instance as Singleton<T>;
                _ins.OnInit();
            } 
            return instance;
        }

        public static T GetInstance_nogc()
        {
            if (instance == null)
            {
                instance = Activator.CreateInstance<T>();
                Singleton<T> _ins = instance as Singleton<T>;
                _ins.OnInit();
            }
            return instance;
        }

        public void DestoryInstance()
        {
            Singleton<T> _ins = instance as Singleton<T>;
            _ins.UnInit();
        }

        public virtual void OnInit() { }
        public virtual void UnInit() { }
    }

    /*
    // 单利模式：一个类只有一个对象
    class SingletonPatterm
    {
        static void Main(string[] args)
        {
            Emperor em = Emperor.GetInstance();
            em.Call();

            Console.ReadLine();
        }
    }
    */
}
