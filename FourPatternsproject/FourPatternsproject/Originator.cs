using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourPatternsproject
{
    public class Originator
    {
        private List<FoodProduct> foods = new List<FoodProduct>();
        private List<Observer> observers = new List<Observer>();
        private State state;

        public Originator() { }

        public void addState(int stateId, string stateName, string description, Context context, CareTaker careTaker)
        {
            setState(new State(stateId, stateName, description, context));
            careTaker.add(saveStateToMemento());
        }

        public void setState(State state)
        {
            this.state = state;
            notifyAllObservers();
        }

        public State getState()
        {
            return state;
        }

        public void attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void notifyAllObservers()
        {
            foreach (Observer observer in observers)
            {
                observer.update(state, getFoods());
            }
        }

        public Memento saveStateToMemento()
        {
            return new Memento(state);
        }

        public void getStateFromMemento(Memento memento)
        {
            state = memento.getState();
            notifyAllObservers();
        }

        public State getOnlyStateFromMemento(Memento memento)
        {
            return memento.getState();
        }

        //Products
        public void instantiateFoods()
        {
            foods.Add(new FoodProduct("Gusto's Shrimp Pasta", "Shrimp, Leek, and Spinach Pasta", 15.50, 5));
            foods.Add(new FoodProduct("Gusto's Chicken Prosciutto", "Chicken, Zucchini, and Prosciutto", 12.50, 7));
            foods.Add(new FoodProduct("Gusto's Salmon Rice", "Spicy Salmon With Bok Choy and Rice", 10.50, 10));
            foods.Add(new FoodProduct("Gusto's Chicken", "Baked Pecorino Chicken", 8.50, 5));
            foods.Add(new FoodProduct("Gusto's Turkey Pasta", "Pasta With Turkey and Broccoli", 11.50, 10));
            foods.Add(new FoodProduct("Gusto's Special Pasta", "Steak With Roasted Parsnips, Tomatoes, and Scallions", 16.50, 2));
            
        }

        public void updateFoodList()
        {
            List<FoodProduct> returnList = new List<FoodProduct>(); ;
            foreach (FoodProduct food in foods) {
                if(food.availableInStock != 0)
                {
                    returnList.Add(food);
                }
                else
                {
                    continue;
                }
            }

            foods = returnList;
        }
         
        public List<object> getFoods()
        {
            List<object> temporary = new List<object>();
            foreach (FoodProduct food in foods)
            {
                temporary.Add(food);
            }

            return temporary;
        }
        
        public void changeStock(int index)
        {
            foods[index].availableInStock -= 1;
        }    
    }
}
