using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourPatternsproject
{
    internal class InsertMoney : Strategy
    {
        Form1 form;
        public InsertMoney(Form1 form)
        {
            this.form = form;
        }
        public void doOperation(Originator originator, CareTaker careTaker, string selectedFood)
        {
            form.lstFood.Clear();
            form.lstFood.View = View.List;
            List<object> foodList = originator.getFoods();

            foreach (FoodProduct food in foodList)
            {
                if (selectedFood.Contains(food.name))
                {
                    originator.changeStock(foodList.IndexOf(food));
                    break;
                }
                else
                {
                    continue;
                }

            }

            form.lstFood.Items.Add("The transaction is complete!!");
            form.lstFood.Items.Add("Please don't forget to take your food!!");

            originator.getStateFromMemento(careTaker.get(3));
        }
    }
}
