using System;
using System.Collections;

namespace ModuleObserverPattern
{
    public interface IObserver
    {
        void Update(float temperature, float humidity, float pressure);
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    public interface IElementDisplay
    {
        void Display();
    }

    // this is the observer implementation:
    class CurrentConditionsDisplay : IObserver, IElementDisplay 
    {
        private float temperature;
        private float humidity;
        private ISubject weatherData;

        public CurrentConditionsDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        void IObserver.Update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            Display();
        }

        public void Display()
        {
            Console.WriteLine("Current conditions: {0}F degrees and {1}% humidity", temperature, humidity);
        }
    }

    //this is a subject implementation:
    class WeatherData : ISubject
    {
        private ArrayList observers;
        private float temperature{ get; set; }
        private float humidity{ get; set; }
        private float pressure{ get; set; }

        public WeatherData()
        {
            observers = new ArrayList();
        }

        void ISubject.RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }
        void ISubject.RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach(IObserver o in observers)
            {
                o.Update(temperature, humidity, pressure);
            }
        }

        public void ChangedMeasurements()
        {
            NotifyObservers();
        }

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            ChangedMeasurements();
        }
    }
}


