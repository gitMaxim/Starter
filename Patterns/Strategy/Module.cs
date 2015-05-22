using System;

namespace ModuleDuckPattern
{
    // SOUNDS:
    public interface QuackBehavior
    {
        void quack();
    }

    class Quack : QuackBehavior
    {
        void QuackBehavior.quack()
        {
            Console.WriteLine("Quack");
        }
    }

    class Squeak : QuackBehavior
    {
        void QuackBehavior.quack()
        {
            Console.WriteLine("Squeak");
        }
    }

    class MuteQuack : QuackBehavior
    {
        void QuackBehavior.quack()
        {
            Console.WriteLine("<< Silence >>");
        }
    }

    //FLYING:
    public interface FlyBehavior
    {
        void fly();
    }

    class FlyWithWings : FlyBehavior
    {
        void FlyBehavior.fly()
        {
            Console.WriteLine("I'm flying!");
        }
    }

    class FlyNoWay : FlyBehavior
    {
        void FlyBehavior.fly()
        {
            Console.WriteLine("I can't fly!");
        }
    }

    class FlyRocketPowered : FlyBehavior
    {
        public void fly()
        {
            Console.WriteLine("I'm flying with a rocket!");
        }
    }
    // DUCKS
    abstract class Duck : QuackBehavior, FlyBehavior
    {
        public Duck() { }

        public abstract void Display();

        void QuackBehavior.quack() { }
        public QuackBehavior quackBehavior;
        public void PerformQuack()
        {
            quackBehavior.quack();
        }
        public void setQuackBegavior(QuackBehavior qb)
        {
            quackBehavior = qb;
        }

        void FlyBehavior.fly() { }
        public FlyBehavior flyBehavior;
        public void PerformFly()
        {
            flyBehavior.fly();
        }
        public void setFlyBegavior(FlyBehavior fb)
        {
            flyBehavior = fb;
        }

        public void Swim()
        {
            Console.WriteLine("All ducks float, even decoys!");
        }
    }

    class MallardDuck : Duck
    {
        public MallardDuck()
        {
            quackBehavior = new Quack();
            flyBehavior = new FlyWithWings();
        }

        public override void Display()
        {
            Console.WriteLine("I'm a real Mallard duck");
        }
    }

    class ModelDuck : Duck
    {
        public ModelDuck()
        {
            flyBehavior = new FlyNoWay();
            quackBehavior = new Quack();
        }

        public override void Display()
        {
            Console.WriteLine("I'm a model duck.");
        }
    }
}