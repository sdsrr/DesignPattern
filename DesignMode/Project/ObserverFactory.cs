using System;
using System.Collections.Generic;


namespace Project
{
    //原型接口
    public interface IClone
    {
        IClone ICone();
    }

    public class Produce : IClone
    {
        private bool isValid = false;
        private string name = "";
        public Produce(string val, ProduceMgr mgr)
        {
            if (mgr.CanCreate())
            {
                this.name = val;
                this.isValid = true;
            }
        }
        public IClone ICone()
        {
            IClone iclone = (IClone)MemberwiseClone();
            return iclone;
        }
        public void Call()
        {
            //只能由mgr创建的对象能被有效访问，其他地方创建的对象即使能创建也不能使用
            if (!isValid) return;
            Console.WriteLine("this is produce call " + name);
        }
    }

    //产品管理器，控制产生产品实例，且保证只能通过ProduceMgr创建
    public class ProduceMgr
    {
        private bool canCreate = false;
        public bool CanCreate() { return canCreate; }

        public Produce CreateProduce(string val)
        {
            //创建前打开
            canCreate = true;
            Produce produce = new Produce(val, this);
            //触发事件
            new Event(EventType.CreateProduce, produce);
            canCreate = false;
            return produce;
        }

        public Produce CloneProduce(Produce produce)
        {
            Produce iclone = (Produce)produce.ICone();
            //触发事件
            new Event(EventType.ICloneProduce, iclone);
            return iclone;
        }
    }

    public enum EventType
    {
        CreateProduce,
        ICloneProduce,
    }

    //事件处理对象
    public abstract class DealEvent
    {
        //中介对象，可通过中介对象访问,因为EventPatcher是单例，也可以自己去取
        private EventPatcher patcher;
        public DealEvent(EventPatcher p) { patcher = p; }
        public abstract void Deal(Event ev);
    }
    public class CreateProEvent : DealEvent
    {
        public CreateProEvent(EventPatcher p) : base(p) {}

        public override void Deal(Event ev)
        {
            Console.WriteLine("create new produce ");
            ev.produce.Call();
        }
    }
    public class ICloneProEvent : DealEvent
    {
        public ICloneProEvent(EventPatcher p) : base(p) {}

        public override void Deal(Event ev)
        {
            Console.WriteLine("iclone produce ");
            ev.produce.Call();
        }
    }

    //观察者模式_抽象观察者
    public interface Observer
    {
        void Update(Event ev);
    }

    //事件派发器作为观察者，将具体事件派发子类处理
    public class EventPatcher : Observer
    {
        //保证唯一使用单例
        private static EventPatcher _instance = new EventPatcher();
        private EventPatcher() { }
        public static EventPatcher GetInstance(){return _instance;}

        //中介者管理事件处理对象
        private static Dictionary<EventType, DealEvent> list = new Dictionary<EventType, DealEvent>
        {
            {EventType.CreateProduce, new CreateProEvent(_instance) },
            {EventType.ICloneProduce, new  ICloneProEvent(_instance)}
        };

        //观察者模式，回调事件
        public void Update(Event ev)
        {
            DealEvent dealEvent = list[ev.type];
            dealEvent.Deal(ev);
        }
    }


    //观察者模式_被观察接口
    public abstract class Obserible
    {
        public Observer observer;
        public void SetObserver(Observer obs) { this.observer = obs; }
        public void Notify(Event ev) { observer.Update(ev); }
    }

    //触发事件类型，本身为被观察者
    public class Event : Obserible
    {
        public EventType type;
        //桥接模式连接Event与Produce
        public Produce produce;

        public Event(EventType type, Produce pro)
        {
            this.type = type;
            this.produce = pro;
            //事件触发器为观察者,创建时触发事件，通知事件触发器
            SetObserver(EventPatcher.GetInstance());
            Notify(this);
        } 
    }

    /*
     * 原型模式 + 观察者 + 单例 + 桥梁 + 中介
     *
     */
    public class ObserverFactory
    {
        /*
        static void Main(string[] args)
        {
            ProduceMgr mgr = new ProduceMgr();
            Produce apple = mgr.CreateProduce("苹果");
            mgr.CreateProduce("香蕉");
            mgr.CloneProduce(apple);
            Console.ReadLine();
        }
        */
    }
}
