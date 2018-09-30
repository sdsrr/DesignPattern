using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DesignMode
{
    public interface IClone
    {
        IClone ILowClone();
        IClone IDeepClone();
    }

    [Serializable] //IDeepClone需要
    public class Prototype : IClone
    {
        public string name;
        public List<int> list = new List<int>();

        public IClone ILowClone()
        {
            Prototype clone = (Prototype)MemberwiseClone();
            //引用类型要单独创建
            //clone.list = new List<int>(list);
            return clone;
        }

        public IClone IDeepClone()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, this);
            memoryStream.Position = 0;
            return (IClone)formatter.Deserialize(memoryStream);
        }

        public override string ToString()
        {
            return "name: " + name + " list count: " + list.Count;
        }
    }

    // 原型模式：数据相似的对象通过拷贝产生，而不是new
    public class PrototypePattern
    {
        /*
        static void Main(string[] args)
        {
            Prototype proto01 = new Prototype();
            proto01.name = "rotot01";
            proto01.list.Add(1);

            Prototype proto02 = (Prototype)proto01.IDeepClone();
            proto02.list.Add(2);

            Console.WriteLine(proto01);
            Console.WriteLine(proto02);
            Console.ReadLine();
        }
        */
    }
}
