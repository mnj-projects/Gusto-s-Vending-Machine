using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternsproject
{
    class Singleton
    {
        private static Originator originatorInstance = new Originator();
        private static CareTaker careTakerInstance = new CareTaker();

        private Singleton() { }

        public static List<object> getInstance()
        {
            List<object> returnList = new List<Object>();

            returnList.Add(originatorInstance);
            returnList.Add(careTakerInstance);

            return returnList;
        }
    }
}
