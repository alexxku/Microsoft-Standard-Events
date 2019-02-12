using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate an event publisher object
            EvtPublisher EP = new EvtPublisher();
            //Instantiate an event subscriber object
            EvtSubscriber ES = new EvtSubscriber();
            EP.Evt += ES.HandleTheEvent;

            //Call the CheckBalance method on the EP object
            // it will invoke the ep.evt delegate if the balance exceeds 250
            EP.CheckBalance(251);

        }
    }

    public class EvtPublisher
    {
        public EventHandler <EvtArgsClass> Evt;

        public void CheckBalance(int x)
        {
            if (x > 250)
            {
                EvtArgsClass EAC = new EvtArgsClass("Balance exceeds 250...");
                Evt(this, EAC);
            }
            else
                Console.WriteLine("This is the correct value");
        }
    }

    public class EvtSubscriber
    {
        public void HandleTheEvent(object sender, EvtArgsClass e)
        {
            Console.WriteLine($"Attention! {sender} advises {e.message}");
        }
    }

    public class EvtArgsClass : EventArgs
    {
        public EvtArgsClass(string str)
        {
            msg = str;
        }
        private string msg;
        public string message
        {
            get { return msg; }
        }
    }
}
