using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternsproject
{
    public class Context
    {
        private Strategy strategy;

        public Context(Strategy strategy)
        {
            this.strategy = strategy;
        }

        public void executeStrategy(Originator originator, CareTaker careTaker, string selectedFood)
        {
            strategy.doOperation(originator, careTaker, selectedFood);
        }
    }
}
