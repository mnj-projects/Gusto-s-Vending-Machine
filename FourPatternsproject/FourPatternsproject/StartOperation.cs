﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourPatternsproject
{
    internal class StartOperation : Strategy
    {
        Form1 form;
        public StartOperation(Form1 form)
        {
            this.form = form;
        }

        public void doOperation(Originator originator, CareTaker careTaker, string selectedFood)
        {
            form.lstFood.Clear();
            form.lstFood.View = View.Details;
            form.lstFood.Columns.Add("Name").Width = 150;
            form.lstFood.Columns.Add("Description").Width = 300;
            form.lstFood.Columns.Add("Price").Width = 100;
            form.lstFood.GridLines = true;

            foreach (FoodProduct food in originator.getFoods())
            {
                form.lstFood.Items.Add(new ListViewItem(new string[] { food.name, food.description, "$ " + food.price.ToString(), food.availableInStock.ToString()}));
            }

            originator.getStateFromMemento(careTaker.get(1));
        }
    }
}
