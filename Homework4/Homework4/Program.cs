using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            var naoZhong1 = new Naozhong();
            //注册
            naoZhong1.Add(new Fuqin());
            naoZhong1.Add(new Erzi());
            //订闹钟
            naoZhong1.SetNotifyTime(DateTime.Now.AddSeconds(10));
            Console.Read();
        }
    }
    //观察者
    public interface IObserver
    {
        void WakeUp();
    }
    //被观察者
    public interface ISubject
    {
        IList<IObserver> Observers
        {
            get;
            set;
        }
        void Add(IObserver ob);
        void Delete(IObserver ob);
        void Notify();
    }
    //闹钟
    public class Naozhong : ISubject
    {
        public Naozhong()
        {
            Observers = new List<IObserver>();
        }
        public IList<IObserver> Observers
        {
            get;
            set;
        }
        public DateTime Time
        {
            get;
            set;
        }
        private bool isSetTime;
        public void Add(IObserver ob)
        {
            Observers.Add(ob);
        }
        public void Delete(IObserver ob)
        {
            Observers.Remove(ob);
        }
        public void Notify()
        {
            foreach (var ob in Observers)
            {
                ob.WakeUp();
            }
        }
        //上闹钟
        public void SetNotifyTime(DateTime time)
        {
            if (time > DateTime.Now)
            {
                Time = time;
                isSetTime = true;
                //如果怕影响响应，这里应该分出一个线程
                Run();
            }
        }
        private void Run()
        {
            while (isSetTime)
            {
                if (Time <= DateTime.Now)
                {
                    Console.WriteLine(Time.ToShortTimeString());
                    Notify();
                    isSetTime = false;
                }
                System.Threading.Thread.Sleep(200);
            }
        }
    }
    //父亲
    public class Fuqin : IObserver
    {
        public void WakeUp()
        {
            Console.WriteLine("my son,it is time to get up!");
        }
    }
    //儿子
    public class Erzi : IObserver
    {
        public void WakeUp()
        {
            Console.WriteLine("dad,it is time to get up!");
        }
    }
}
