using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    public class WaiKe
    {
        public void Call() { Console.WriteLine("this is waike "); }
    }

    public class ZhuYuanKe
    {
        public void Call() { Console.WriteLine("this is zhuyuan "); }
    }

    public class JiaoFeiKe
    {
        public void Call() { Console.WriteLine("this is jiaofei "); }
    }

    //封装三个子类
    public class Hospital
    {
        JiaoFeiKe jiaofei = new JiaoFeiKe();
        ZhuYuanKe zhuyuan = new ZhuYuanKe();
        WaiKe waike = new WaiKe();

        public void Visit()
        {
            jiaofei.Call();
            waike.Call();
            zhuyuan.Call();
        }
    }

    //门面模式：将相关联的类封装为一个子系统，对外提供接口，方便上层调用
    public class FacadePattern
    {
        /*
        static void Main(string[] args)
        {
            Hospital hostial = new Hospital();
            hostial.Visit();
            Console.ReadLine();
        }
        */
    }
}
