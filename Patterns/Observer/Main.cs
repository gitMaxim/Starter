using System;
using ModuleObserverPattern;

// Pattern   #2 (p. 108)
//
// Name     "Observer"
//   
// TL; DR   "One-to-Many" dependency between the objects:
//          by changning one objects' state it updates dependent objects states.
namespace ObserverPattern
{
    class WeatherStation
    {
        static void Main(string[] args)
        {
            // Creating subject (+ creates ListArray of observers): 
            WeatherData weatherData = new WeatherData();

            // Creating observer (+ pass the subjects reference we creating for):
            CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);

            // By changing subjects info we notify observers (+ calls Display() in the observer):
            weatherData.SetMeasurements(80f, 65f, 30.4f);
            weatherData.SetMeasurements(82f, 70f, 29.2f);
            weatherData.SetMeasurements(78f, 90f, 29.2f);

            Console.ReadLine();
        }
    }
}
