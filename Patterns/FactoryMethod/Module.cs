using System;
using System.Collections;

namespace ModuleFactoryMethodPattern
{
    // PIZZA:
    abstract class Pizza
    {
        public string Name { get; set; }
        public string Dough { get; set; }
        public string Sauce { get; set; }
        public ArrayList toppings = new ArrayList();

        public void Prepare()
        {
            Console.WriteLine("Preparing {0}", Name);
            Console.WriteLine("Tossing {0}", Dough);
            Console.WriteLine("Adding {0}", Sauce);
            Console.WriteLine("Adding toppings: ");
            foreach(string top in toppings)
            {
                Console.WriteLine("  {0}", top);
            }
        }

        public void Bake()
        {
            Console.WriteLine("Bake for 25 minutes at 350");
        }

        public virtual void Cut()
        {
            Console.WriteLine("Cutting the pizza into diagonal slices");
        }

        public void Box()
        {
            Console.WriteLine("Place pizza in official PizzaStore box");
        }
    }

    class NYStyleCheesePizza : Pizza
    {
        public NYStyleCheesePizza()
        {
            Name = "NY Style Sauce and Cheese Pizza";
            Dough = "Thin Crust Dough";
            Sauce = "Marinara Sauce";

            toppings.Add("Grated Reggiano Cheese");
        }
    }

    class ChicagoStyleCheesePizza : Pizza
    {
        public ChicagoStyleCheesePizza()
        {
            Name = "Chicago Style Cheese Pizza";
            Dough = "Extra Thik Crust Dough";
            Sauce = "Plum Tomato Sauce";

            toppings.Add("Shredded Mozzarella Cheese");
        }

        public override void Cut()
        {
            Console.WriteLine("Cutting the pizza into square slices");
        }
    }

    // FACTORY METHOD:
    abstract class PizzaStore
    {
        public Pizza orderPizza(string type)
        {
            Pizza pizza = createPizza(type);

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }

        protected abstract Pizza createPizza(string type);
    }

    // PIZZA STORE:
    class NYStylePizzaStore : PizzaStore
    {
        protected override Pizza createPizza(string type)
        {
            Pizza pizza = null;
            if (type.Equals("cheese"))
                pizza = new NYStyleCheesePizza();

            return pizza;
        }
    }

    class ChicagoStylePizzaStore : PizzaStore
    {
        protected override Pizza createPizza(string type)
        {
            Pizza pizza = null;
            if (type.Equals("cheese"))
                pizza = new ChicagoStyleCheesePizza();

            return pizza;
        }
    }
}
