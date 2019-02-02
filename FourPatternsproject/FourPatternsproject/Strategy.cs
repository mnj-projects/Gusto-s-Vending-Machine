using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternsproject
{
    public interface Strategy
    {
        void doOperation(Originator originator, CareTaker careTaker, string selectedFood);
    }
}
