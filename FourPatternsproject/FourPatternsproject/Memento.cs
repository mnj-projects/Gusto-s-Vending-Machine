using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternsproject
{
    public class Memento
    {
        private State state;

        public Memento(State state)
        {
            this.state = state;
        }

        public State getState()
        {
            return state;
        }
    }
}
