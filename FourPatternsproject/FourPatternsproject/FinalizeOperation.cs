using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourPatternsproject
{
    internal class FinalizeOperation : Strategy
    {
        Form1 form;
        public FinalizeOperation(Form1 form)
        {
            this.form = form;
        }
        public void doOperation(Originator originator, CareTaker careTaker, string selectedFood)
        {
            form.lstFood.Clear();
            form.lstFood.View = View.List;

            form.lstFood.Items.Add("You have taken your food!!");
            form.lstFood.Items.Add("Have a wounderful meal!!");
            
            restart(originator, careTaker);

           

        }

        private void restart(Originator originator, CareTaker careTaker)
        {
            Thread.Sleep(2000);
            originator.getStateFromMemento(careTaker.get(0));
            form.lstFood.View = View.List;
            form.lstFood.Items.Add("Welcome to Gustos's Vending Machine!!");
            form.lstFood.Items.Add("Press the start button to start your order!!!");

            originator.updateFoodList();
        }
    }
}
