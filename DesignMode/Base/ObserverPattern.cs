using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    public abstract class Subject
    {
        private List<Observer> observers = new List<Observer>();
        public void AddObseror(Observer obj) { observers.Add(obj); }
        public void DelObserver(Observer obj) {observers.Remove(obj);}
        public void NotifyObserver(Subject subject, string param)
        {
            for (int i = 0; i < observers.Count; i++)
                observers[i].Notify(subject, param);
        }
    }

    public class Thief : Subject
    {
        string name;
        public Thief(string val) { name = val; }
        public void Steal()
        {
            Console.WriteLine("this is " + name);
            NotifyObserver(this, name);
        }
    }

    public interface Observer
    {
        void Notify(Subject subject, string param);
    }

    public class Police : Observer
    {
        public void Notify(Subject subject, string param) { Console.WriteLine("find a thief" + param); }
    }

    //观察模式：建立一种依赖关系，当对象的状态改变，依赖的对象得到通知
    public class ObserverPattern
    {
        /*
         static void Main(string[] args)
         {
             Observer police = new Police();
             Thief thief01 = new Thief("thief 01");
             Thief thief02 = new Thief("thief 02");
             thief01.AddObseror(police);
             thief02.AddObseror(police);
             thief01.Steal();
             Console.ReadLine();
         }
         */
    }
}
