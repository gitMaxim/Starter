using System;
using ModuleFactoryMethodPattern;

// Pattern   #4 (p. 163)
//
// Name     "Factory Method"
//   
// TL; DR   All factory methods incapsulate object creating operations.   
//          Factory method allows subclasses to choose an object to create.
//
namespace FactoryMethodPattern
{
    class PizzaTestDrive
    {
        static void Main(string[] args)
        {
            PizzaStore nyStore = new NYStylePizzaStore();
            PizzaStore chicagoStore = new ChicagoStylePizzaStore();

            Pizza pizza = nyStore.orderPizza("cheese");
            Console.WriteLine("Ethan ordered a {0}\n", pizza.Name);

            pizza = chicagoStore.orderPizza("cheese");
            Console.WriteLine("Joel ordered a {0}", pizza.Name);

            Console.ReadLine();
        }
    }
}
