using System;

namespace ModuleDecoratorPattern
{
    // ABSTRACTIONS:
    abstract class Beverage
    {
        public virtual string Description { get; set; }
        
        public Beverage()
        {
            Description = "Unknown Beverage";
        }
                
        public abstract double Cost();
    }

    abstract class CondimentDecorator : Beverage
    {
        public abstract override string Description { get; set; }
    }

    // DRINKS:
    class Espresso : Beverage
    {
        public Espresso()
        {
            Description = "Espresso";
        }
        public override double Cost()
        {
            return 1.99d;
        }
    }

    class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            Description = "House Blend Coffee";
        }

        public override double Cost()
        {
            return 0.89d;
        }
    }

    class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            Description = "Dark Roast Coffee";
        }

        public override double Cost()
        {
            return 0.99d;
        }
    }

    class Decaf : Beverage
    {
        public Decaf()
        {
            Description = "Decaf Coffee";
        }

        public override double Cost()
        {
            return 1.05d;
        }
    }

    // CONDIMENTS:
    class Mocha : CondimentDecorator
    {
        Beverage beverage;

        public Mocha(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string Description
        {
            get { return beverage.Description + ", Mocha"; }
            set { }
        }

        public override double Cost()
        {
            return 0.20d + beverage.Cost();
        }
    }

    class Soy : CondimentDecorator
    {
        Beverage beverage;

        public Soy(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string Description
        {
            get { return beverage.Description + ", Soy"; }
            set { }
        }

        public override double Cost()
        {
            return 0.15d + beverage.Cost();
        }
    }

    class Whip : CondimentDecorator
    {
        Beverage beverage;

        public Whip(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override string Description
        {
            get { return beverage.Description + ", Whip"; }
            set { }
        }

        public override double Cost()
        {
            return 0.10d + beverage.Cost();
        }
    }

}
