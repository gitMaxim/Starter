using System;

namespace AbstractFactoryPatternModule
{
    // PIZZA:
    abstract class Pizza
    {
        public string Name { get; set; }
        protected IDough Dough;
        protected ISauce Sauce;
        protected IVeggies[] Veggies;
        protected ICheese Cheese;
        protected IPepperoni Pepperoni;
        protected IClams Clam;

        public abstract void Prepare();

        public virtual void Bake()
        {
            Console.WriteLine("Bake for 25 minutes at 350");
        }

        public virtual void Cut()
        {
            Console.WriteLine("Cutting the pizza intop diagonal slices");
        }

        public virtual void Box()
        {
            Console.WriteLine("Place pizze in official PizzaStore box");
        }

        public virtual void Description()
        {
            Console.WriteLine("Pizza");
        }
    }

    // Now we can make different styles of cheese pizza,
    // by calling different factories:
    class CheesePizza : Pizza
    {
        private PizzaIngredientFactory IngredientFactory;
       
        public CheesePizza(PizzaIngredientFactory IngredientFactory)
        {
            this.IngredientFactory = IngredientFactory;
        }

        public override void Prepare()
        {
            Dough = IngredientFactory.CreateDough();
            Sauce = IngredientFactory.CreateSauce();
            Cheese = IngredientFactory.CreateCheese();
            this.Description();
        }

        public override void Description()
        {
            Console.WriteLine("Preparing: {0}", Name);
            Dough.Description();
            Sauce.Description();
            Cheese.Description();
        }
    }

    class ClamPizza : Pizza
    {
        private PizzaIngredientFactory IngredientFactory;
       
        public ClamPizza(PizzaIngredientFactory IngredientFactory)
        {
            this.IngredientFactory = IngredientFactory;
        }

        public override void Prepare()
        {
            Dough = IngredientFactory.CreateDough();
            Sauce = IngredientFactory.CreateSauce();
            Cheese = IngredientFactory.CreateCheese();
            Clam = IngredientFactory.CreateClam();
            this.Description();
        }

        public override void Description()
        {
            Console.WriteLine("Preparing: {0}", Name); 
            Dough.Description();
            Sauce.Description();
            Cheese.Description();
            Clam.Description();
        }
    }

    abstract class PizzaStore
    {
        public Pizza orderPizza(string type)
        {
            Pizza pizza = CreatePizza(type);

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }

        protected abstract Pizza CreatePizza(string type);
    }

    class NYPizzaStore : PizzaStore
    {
       protected override Pizza CreatePizza(string type)
        {
            Pizza pizza = null;
            PizzaIngredientFactory IngredientFactory = new NYPizzaIngredientFactory();

            switch (type)
            {
                case "cheese":
                    pizza = new CheesePizza(IngredientFactory);
                    pizza.Name = "New York Style Cheese Pizza";
                    break;
                case "clam":
                    pizza = new ClamPizza(IngredientFactory);
                    pizza.Name = "New York Style Clam Pizza";
                    break;
                // etc...
            }

            return pizza;
        }
    }

    class ChicagoPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string type)
        {
            Pizza pizza = null;
            PizzaIngredientFactory IngredientFactory = new NYPizzaIngredientFactory();

            switch (type)
            {
                case "cheese":
                    pizza = new CheesePizza(IngredientFactory);
                    pizza.Name = "Chicago Style Cheese Pizza";
                    break;
                case "clam":
                    pizza = new ClamPizza(IngredientFactory);
                    pizza.Name = "Chicago Style Clam Pizza";
                    break;
                // etc...
            }

            return pizza;
        }
    }


    //Instead of FactoryMethodPattern example, here factory chooses what
    //ingredients to use for certain pizza, not store:
    interface PizzaIngredientFactory
    {
        IDough CreateDough();
        ISauce CreateSauce();
        ICheese CreateCheese();
        IVeggies[] CreateVeggies();
        IPepperoni CreatePepperoni();
        IClams CreateClam();
    }

    // Pizza's ingredient factories:
    class NYPizzaIngredientFactory : PizzaIngredientFactory
    {
        public IDough CreateDough()
        {
            return new ThinCrustDough();
        }

        public ISauce CreateSauce()
        {
            return new MarinaraSauce();
        }

        public ICheese CreateCheese()
        {
            return new ReggianoCheese();
        }

        public IVeggies[] CreateVeggies()
        {
            IVeggies[] Veggies = { new Garlic(), new Onion(), new Mushroom(), new RedPepper() };
            return Veggies;
        }

        public IPepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public IClams CreateClam()
        {
            return new FreshClams();
        }
    }

    class ChicagoPizzaIngredientFactory : PizzaIngredientFactory
    {
        public IDough CreateDough()
        {
            return new ThickCrustDough();
        }

        public ISauce CreateSauce()
        {
            return new PlumTomatoSauce();
        }

        public ICheese CreateCheese()
        {
            return new Mozzarella();
        }

        public IVeggies[] CreateVeggies()
        {
            IVeggies[] Veggies = { new BlackOlives(), new Spinach(), new EggPlant() };
            return Veggies;
        }

        public IPepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public IClams CreateClam()
        {
            return new FrozenClams();
        }
    }

    // Long and not relevant to read:
    #region Ingredients Interfaces

    interface IIngredient
    {
        void Description();
    }

    interface IDough : IIngredient
    {
        
    }

    interface ISauce : IIngredient
    {
     
    }

    interface ICheese : IIngredient
    {

    }

    interface IVeggies : IIngredient
    {

    }

    interface IPepperoni : IIngredient
    {
    }

    interface IClams : IIngredient
    {

    }
    #endregion

    #region Ingredients Classes
    class ThinCrustDough : IDough
    {
        public void Description()
        {
            Console.WriteLine("Thin Crust Dough");
        }
    }

    class ThickCrustDough : IDough
    {
        public void Description()
        {
            Console.WriteLine("Thick Crust Dough");
        }
    }

    class MarinaraSauce : ISauce
    {
        public void Description()
        {
            Console.WriteLine("Marinara Sauce");
        }
    }

    class PlumTomatoSauce : ISauce
    {
        public void Description()
        {
            Console.WriteLine("Plum Tomato Sauce");
        } 
    }

    class ReggianoCheese : ICheese
    {
        public void Description()
        {
            Console.WriteLine("Reggiano Cheese");
        }
    }

    class Mozzarella : ICheese
    {
        public void Description()
        {
            Console.WriteLine("Mozzarella Cheese");
        }
    }

    class Garlic : IVeggies
    {
        public void Description()
        {
            Console.WriteLine("Garlic");
        }
    }

    class Onion : IVeggies
    {
        public void Description()
        {
            Console.WriteLine("Onion");
        }
    }

    class Mushroom : IVeggies
    {
        public void Description()
        {
            Console.WriteLine("Mushroom");
        }
    }

    class Spinach : IVeggies
    {
        public void Description()
        {
            Console.WriteLine("Spinach");
        }
    }

    class BlackOlives : IVeggies
    {
        public void Description()
        {
            Console.WriteLine("Black Olives");
        }
    }

    class EggPlant : IVeggies
    {
        public void Description()
        {
            Console.WriteLine("Egg Plant");
        }
    }

    class RedPepper : IVeggies
    {
        public void Description()
        {
            Console.WriteLine("Red Pepper");
        }
    }

    class SlicedPepperoni : IPepperoni
    {
        public void Description()
        {
            Console.WriteLine("Sliced Pepperoni");
        }
    }

    class FreshClams : IClams
    {
        public void Description()
        {
            Console.WriteLine("Fresh Clams");
        }
    }

    class FrozenClams : IClams
    {
        public void Description()
        {
            Console.WriteLine("Frozen Clams");
        }
    }

    #endregion
}
