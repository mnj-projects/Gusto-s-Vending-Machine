using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternsproject
{
    public class State
    {
        public int stateId;
        public string stateName, description;
        public Context context;

        public State(int stateId, string stateName, string description, Context context)
        {
            this.stateId = stateId;
            this.stateName = stateName;
            this.description = description;
            this.context = context;
        }
    }
}
