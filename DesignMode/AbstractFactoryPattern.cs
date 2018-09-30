using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    //file类族
    public interface IFile { void Call(); }

    public class Win_File : IFile
    {
        public void Call()
        {
            Console.WriteLine("this is win file");
        }
    }

    public class IOS_File : IFile
    {
        public void Call()
        {
            Console.WriteLine("this is ios file");
        }
    }

    public class Android_File : IFile
    {
        public void Call()
        {
            Console.WriteLine("this is android file");
        }
    }

    // web类族
    public interface IWeb { void Call(); }

    public class Win_Web : IWeb
    {
        public void Call()
        {
            Console.WriteLine("this is win web");
        }
    }

    public class IOS_Web : IWeb
    {
        public void Call()
        {
            Console.WriteLine("this is ios web");
        }
    }

    public class Android_Web : IWeb
    {
        public void Call()
        {
            Console.WriteLine("this is android web");
        }
    }

    //iweb,ifile类族没有直接联系，但有相同约束条件--平台，相同平台的对象的用一个工厂类创建
    public interface AbstractFactory
    {
        IWeb CreateWeb();
        IFile CreateFile();
    }

    public class AndroidFactory : AbstractFactory
    {
        public IFile CreateFile() { return new Android_File(); }
        public IWeb CreateWeb() { return new Android_Web(); }
    }
    public class WinFactory : AbstractFactory
    {
        public IFile CreateFile() { return new Win_File(); }
        public IWeb CreateWeb() { return new Win_Web(); }
    }
    public class IOSFactory : AbstractFactory
    {
        public IFile CreateFile() { return new IOS_File(); }
        public IWeb CreateWeb() { return new IOS_Web(); }
    }

    //抽象工厂模式：提供创建相互关联的对象的统一接口
    public class AbstractFactoryPattern
    {
        /*
        static void Main(string[] args)
        {
            //上层不知道依赖具体类(android_file/android_web)，只依赖接口ifile/iweb
            AndroidFactory android = new AndroidFactory();
            IFile file = android.CreateFile();
            file.Call();
            IWeb web = android.CreateWeb();
            web.Call();
            Console.ReadLine();
        }
        */
    }
}
