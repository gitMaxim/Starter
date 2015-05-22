using System;
using ModuleDuckPattern;

// Pattern   #1 (p. 60)
//
// Name     "Strategy"
//   
// TL; DR   Incapsulates each family of algorithms, so we can modify
//          them independently.
namespace DuckPattern
{
    class MiniDuckSimulator
    {
        static void Main(string[] args)
        {
            Duck mallard = new MallardDuck();
            mallard.PerformQuack();
            mallard.PerformFly();

            Duck model = new ModelDuck();
            model.PerformFly();
            model.setFlyBegavior(new FlyRocketPowered());
            model.PerformFly();

            Console.ReadLine();
        }
    }
}
