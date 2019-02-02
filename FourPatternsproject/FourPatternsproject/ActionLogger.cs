using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternsproject
{
    class ActionLogger : Observer
    {
        public ActionLogger(Originator subject)
        {
            this.originator = subject;
            originator.attach(this);
        }
        public override void update(State state, List<object> foods)
        {
            Console.WriteLine("logging");
            DateTime today = DateTime.Today;
            using (StreamWriter writer = new StreamWriter("../../log.txt", true))
            {
                writer.WriteLine("--------------------------------------------");
                writer.WriteLine(today.ToString("dd/MM/yyyy"));
                writer.WriteLine("Time: " + string.Format("{0:HH:mm:ss tt}", DateTime.Now));
                writer.WriteLine("********************************************");
                writer.WriteLine("Current Status Information:");
                writer.WriteLine("State at: ");
                writer.WriteLine("\tID: " + state.stateId);
                writer.WriteLine("\tState Name: " + state.stateName);
                
                if(state.stateId == 3 || state.stateId == 4)
                {
                    writer.WriteLine("Foods Available: ");
                    int count = 1;
                    foreach (FoodProduct food in foods)
                    {
                        writer.WriteLine("\t" + count + ". " + food.name + " -> " + food.availableInStock);
                        count++;
                    }
                }
                
                writer.WriteLine("--------------------------------------------");
            }
        }
    }
}
