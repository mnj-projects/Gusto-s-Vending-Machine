using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternsproject
{
    public abstract class Observer
    {
        protected Originator originator;
        public abstract void update(State state, List<object> foods);
    }
}
