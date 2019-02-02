using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourPatternsproject
{
    public partial class Form1 : Form
    {
        //Getting the singleton classes
        static List<object> singeltons = Singleton.getInstance();
        Originator originator = (Originator)singeltons[0];
        CareTaker careTaker = (CareTaker)singeltons[1];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Instantiating the States
            originator.addState(1, "Start Interaction", "Let the system show the display", new Context(new StartOperation(this)), careTaker);
            originator.addState(2, "Choose your food", "choose which food you want to get ffrom the vending machine", new Context(new ChooseOperation(this)), careTaker);
            originator.addState(3, "Insert Money", "Insert the required amount of money", new Context(new InsertMoney(this)), careTaker);
            originator.addState(4, "Take your order", "Take your food from the side and the transaction is complete", new Context(new FinalizeOperation(this)), careTaker);

            //Declaring the first State
            originator.getStateFromMemento(careTaker.get(0));

            //Instantiating Foods for the Vending Machine
            originator.instantiateFoods();

            //Instantiating the obserever classes
            ActionLogger logger = new ActionLogger(originator);
            Monitor monitor = new Monitor(originator);

            //PreText to Display Before transaction

            lstFood.Items.Add("Welcome to Gustos's Vending Machine!!");
            lstFood.Items.Add("Press the start button to start your order!!!");

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (originator.getState() == originator.getOnlyStateFromMemento(careTaker.get(0)))
            {
                originator.getState().context.executeStrategy(originator, careTaker, null);
            }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (originator.getState() == originator.getOnlyStateFromMemento(careTaker.get(1)))
            {
                try
                {
                    string selectedFood = lstFood.SelectedItems[0].ToString();
                    originator.getState().context.executeStrategy(originator, careTaker, selectedFood);

                }
                catch (Exception except)
                {
                    Console.WriteLine("Exception occurred: " + except);
                }
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (originator.getState() == originator.getOnlyStateFromMemento(careTaker.get(2)))
            {
                try
                {
                    string selectedFood = lstFood.Items[0].ToString();
                    originator.getState().context.executeStrategy(originator, careTaker, selectedFood);

                }
                catch (Exception except)
                {
                    Console.WriteLine("Exception occurred: " + except);
                }
            }
        }

        private void btnTakeFood_Click(object sender, EventArgs e)
        {
            if (originator.getState() == originator.getOnlyStateFromMemento(careTaker.get(3)))
            {
                originator.getState().context.executeStrategy(originator, careTaker, null);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (originator.getState() == originator.getOnlyStateFromMemento(careTaker.get(2)))
            {
                originator.getStateFromMemento(careTaker.get(0));
                originator.getState().context.executeStrategy(originator, careTaker, null);
            }
        }
    }
}