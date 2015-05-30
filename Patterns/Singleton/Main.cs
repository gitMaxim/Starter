using System;

// Pattern   #6 (p. 210 + http://csharpindepth.com/Articles/General/Singleton.aspx)
//
// Name     "Singleton"
//   
// TL; DR   Gives a single instance of a class.
//          
namespace SingletonPattern
{
    // DO NOT RECOMMENDED TO USE
    class SingletonNotThreadSafe
    {
        private static SingletonNotThreadSafe instance = null;

        private SingletonNotThreadSafe() { }

        public static SingletonNotThreadSafe Create()
        {
            if (instance == null)
                instance = new SingletonNotThreadSafe();

            return instance;
        }
    }


    class SingletonSimpleThreadSafe
    {
        private static SingletonSimpleThreadSafe instance = null;
        private static readonly object padlock = new object();

        private SingletonSimpleThreadSafe() { }

        public static SingletonSimpleThreadSafe Create
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new SingletonSimpleThreadSafe();
             
                    return instance;
                }
            }
        }
    }


    //Using lambda-stuff:
    class SingletonNET4Type
    {
        private static readonly Lazy<SingletonNET4Type> lazy =
            new Lazy<SingletonNET4Type>(() => new SingletonNET4Type());

        public static SingletonNET4Type Create { get { return lazy.Value; } }

        private SingletonNET4Type()
        {
        }
    }

    class Running
    {
        static void Main(string[] args)
        {
            SingletonNotThreadSafe s1 = SingletonNotThreadSafe.Create();

            SingletonSimpleThreadSafe s2 = SingletonSimpleThreadSafe.Create;

            SingletonNET4Type s3 = SingletonNET4Type.Create;

            if ((s1 != null) && (s2 != null) &&  (s3 != null))
                Console.WriteLine("All instances were created");

            Console.ReadLine();
        }
    }
}
