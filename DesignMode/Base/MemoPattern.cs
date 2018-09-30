using System;
using System.Collections.Generic;
using System.Reflection;

namespace DesignMode
{
    //数据状态
    public class State
    {
        private Dictionary<string, object> list = new Dictionary<string, object>();
        public void SetData(Dictionary<string, object> data) { list = data; }
        public Dictionary<string, object> GetData() { return list; }
    }

    public abstract class Originator
    {
        public State SaveState()
        {
            State state = new State();
            state.SetData(Util.Export(this));
            return state;
        }
        public void RevertState(State state)
        {
            Util.Import(this, state.GetData());
        }
    }
    //
    public class Teacher : Originator
    {
        public string name;
        public void Call() { }
    }

    public class Student : Originator
    {
        public string name;
        public int age;
    }

    //工具类导入类的成员数据为固定格式
    public static class Util
    {
        public static Dictionary<string, object> Export<T>(T instance)
        {
            //将对象的值存到list中返回
            Dictionary<string, object> list = new Dictionary<string, object>();
            FieldInfo[] fields = instance.GetType().GetFields();
            foreach (FieldInfo field in fields)
            {
                if (field.MemberType != MemberTypes.Method)
                    list.Add(field.Name, field.GetValue(instance));
            }
            return list;
        }
        public static void Import<T>(T instance, Dictionary<string, object> list)
        {
            //将list中值设置到instance中
            FieldInfo[] fields = instance.GetType().GetFields();
            foreach (FieldInfo field in fields)
            {
                if (field.MemberType != MemberTypes.Method)
                {
                    object val = list[field.Name];
                    field.SetValue(instance, val);
                }  
            }  
        }
    }

    //备忘者模式:将对象当前状态存储下来，以后可用于还原对象状态
    public class MemoPattern
    {
        /*
        static void Main(string[] args)
        {
            Teacher teacher = new Teacher();
            teacher.name = "teacher01";
            State teacherState = teacher.SaveState();
            teacher.name = "teacher02";
            teacher.RevertState(teacherState);
            Console.WriteLine("teacher name " + teacher.name);

            Student stu = new Student();
            stu.name = "stu01";
            stu.age = 1;
            State stuState = stu.SaveState();
            stu.name = "stu02";
            stu.age = 2;

            stu.RevertState(stuState);
            Console.WriteLine("name " + stu.name + " age " + stu.age);

            PropertyInfo[] properties = teacher.GetType().GetProperties();
            FieldInfo[] fields = teacher.GetType().GetFields();
            MemberInfo[] members = teacher.GetType().GetMembers();

            Console.ReadLine();
        }
        */
    }
}
