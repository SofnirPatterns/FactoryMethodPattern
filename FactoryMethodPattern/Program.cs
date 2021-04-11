using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaStore nyStylePizzaStore = new NYStylePizzaStore();            
            Pizza pizza = nyStylePizzaStore.OrderPizza(PizzaType.Cheese);
            Console.WriteLine($"Ordered a {pizza.GetName()}\n");

            PizzaStore chicagoPizzaStore = new ChicagoStylePizzaStore();            
            pizza = chicagoPizzaStore.OrderPizza(PizzaType.Cheese);
            Console.WriteLine($"Ordered a {pizza.GetName()}\n");

            Console.ReadKey();
        }

        public abstract class Pizza
        {
            protected string Name;
            protected string Dough;
            protected string Sauce;
            protected List<string> Toppings = new List<string>();            

            public void Prepare()
            {
                Console.WriteLine($"Preparing {this.Name}");
                Console.WriteLine($"Tossing dough...");
                Console.WriteLine($"Adding sauce...");
                Console.WriteLine($"Adding toppings...");
                foreach (string topping in this.Toppings)
                {
                    Console.WriteLine($" {topping}");
                }
            }

            public string GetName()
            {
                return this.Name;
            }

            public void Bake()
            {
                Console.WriteLine("Bake for 25 miutes at 350");
            }

            public void Cut()
            {
                Console.WriteLine("Cutting the pizza into diagonal slices");
            }

            public void Box()
            {
                Console.WriteLine("Place pizza in offical PizzaStore box");
            }
        }

        public class NYStyleCheesePizza : Pizza
        {
            public NYStyleCheesePizza() : base()
            {
                this.Name = "NY Style Sauce and Cheese Pizza";
                this.Dough = "Thin Crust Dough";
                this.Sauce = "Marinara Sauce";
                this.Toppings.Add("Grated Reggiano Cheese");
            }
        }        

        public class ChicagoStyleCheesePizza : Pizza
        {
            public ChicagoStyleCheesePizza() : base()
            {
                this.Name = "Chicago Style Deep Dish Cheese Pizza";
                this.Dough = "Extra Thick Crust Dough";
                this.Sauce = "Plum Tomato Sauce";
                this.Toppings.Add("Shredded Mozarella Cheese");
            }

            public void Cut()
            {
                Console.WriteLine("Cutting the pizza into square slices");
            }
        }

        public enum PizzaType
        {
            Cheese            
        }

        public abstract class PizzaStore
        {            
            public Pizza OrderPizza(PizzaType type)
            {
                Pizza pizza = CreatePizza(type);

                pizza.Prepare();
                pizza.Bake();
                pizza.Cut();
                pizza.Box();

                return pizza;
            }

            protected abstract Pizza CreatePizza(PizzaType type);
        }

        public class NYStylePizzaStore : PizzaStore
        {            
            protected override Pizza CreatePizza(PizzaType type)
            {
                switch (type)
                {
                    case PizzaType.Cheese:
                        return new NYStyleCheesePizza();
                    default:
                        return null;
                }
            }
        }

        public class ChicagoStylePizzaStore : PizzaStore
        {            
            protected override Pizza CreatePizza(PizzaType type)
            {
                switch (type)
                {
                    case PizzaType.Cheese:
                        return new ChicagoStyleCheesePizza();
                    default:
                        return null;
                }
            }
        }        
    }
}
