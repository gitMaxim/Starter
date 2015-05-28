using System;
using AbstractFactoryPatternModule;

// Pattern   #5 (p. 189)
//
// Name     "Abstract Factory"
//   
// TL; DR   Factory Method defines object creating interface (PizzaIngredientFactory),
//          but also allows subclasses to choose what object to create.
//
namespace FactoryMethodPattern
{
    class PizzaTestDrive
    {
        static void Main(string[] args)
        {
            PizzaStore nyStore = new NYPizzaStore();
            PizzaStore chicagoStore = new ChicagoPizzaStore();

            Pizza pizza = null;
            pizza = nyStore.orderPizza("cheese");
            Console.WriteLine("\nNow ordering the same in different store:");
            pizza = chicagoStore.orderPizza("cheese");          

            Console.ReadLine();
        }
    }
}
