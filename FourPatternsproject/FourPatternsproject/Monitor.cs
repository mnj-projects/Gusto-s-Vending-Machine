using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternsproject
{
    class Monitor : Observer
    {
        public Monitor(Originator subject)
        {
            this.originator = subject;
            originator.attach(this);
        }
        public override void update(State state, List<object> foods)
        {
            Console.WriteLine("The machine Current Status: ");
            Console.WriteLine("Status ID: " + state.stateId);
            Console.WriteLine("Status Name: " + state.stateName);
            Console.WriteLine("Status Description: " + state.description);
        }
    }
}
