using System;
using System.Collections.Generic;
using System.Threading;

namespace TrafficSignalControlSystem
{
    public enum TrafficSignal
    {
        Red,
        Yellow,
        Green
    }

    // Observer interface
    public interface ITrafficSignalObserver
    {
        void Update(TrafficSignal signal);
        void NotifyEmergency();
    }

    // Subject class
    public class TrafficLight
    {
        private readonly List<ITrafficSignalObserver> _observers = new();
        public TrafficSignal CurrentSignal { get; private set; }
        public int RedDuration { get; set; }
        public int YellowDuration { get; set; }
        public int GreenDuration { get; set; }

        public TrafficLight(int redDuration, int yellowDuration, int greenDuration)
        {
            RedDuration = redDuration;
            YellowDuration = yellowDuration;
            GreenDuration = greenDuration;
            CurrentSignal = TrafficSignal.Red;
        }

        public void AddObserver(ITrafficSignalObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(ITrafficSignalObserver observer)
        {
            _observers.Remove(observer);
        }

        public void ChangeSignal(TrafficSignal newSignal)
        {
            CurrentSignal = newSignal;
            Console.WriteLine($"Signal changed to: {CurrentSignal}");
            NotifyObservers();
        }

        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(CurrentSignal);
            }
        }

        public void RunSignalCycle()
        {
            while (true)
            {
                ChangeSignal(TrafficSignal.Green);
                Thread.Sleep(GreenDuration * 1000);
                
                ChangeSignal(TrafficSignal.Yellow);
                Thread.Sleep(YellowDuration * 1000);
                
                ChangeSignal(TrafficSignal.Red);
                Thread.Sleep(RedDuration * 1000);
            }
        }

        public void HandleEmergency()
        {
            Console.WriteLine("Emergency vehicle approaching! Switching to Red signal immediately!");
            ChangeSignal(TrafficSignal.Red);
            NotifyEmergencyToObservers();
            Thread.Sleep(5000); // Keep the red signal for 5 seconds for safety
            RunSignalCycle(); // resume normal cycle
        }

        private void NotifyEmergencyToObservers()
        {
            foreach (var observer in _observers)
            {
                observer.NotifyEmergency();
            }
        }
    }

    // Example observer implementation
    public class TrafficSignalObserver : ITrafficSignalObserver
    {
        private readonly string _name;

        public TrafficSignalObserver(string name)
        {
            _name = name;
        }

        public void Update(TrafficSignal signal)
        {
            Console.WriteLine($"{_name}: The traffic signal is now {signal}");
        }

        public void NotifyEmergency()
        {
            Console.WriteLine($"{_name}: Alert! An emergency vehicle is approaching!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Traffic Signal Control System");
            TrafficLight trafficLight = new TrafficLight(2, 2, 2); // Red: 30s, Yellow: 5s, Green: 25s
            
            // Create observers
            var observer1 = new TrafficSignalObserver("Observer 1");
            var observer2 = new TrafficSignalObserver("Observer 2");

            // Register observers
            trafficLight.AddObserver(observer1);
            trafficLight.AddObserver(observer2);

            // Run traffic signal cycle in a separate thread
            Thread signalThread = new Thread(new ThreadStart(trafficLight.RunSignalCycle));
            signalThread.Start();

            while (true)
            {
                Console.WriteLine("Enter 'e' to simulate emergency situation or 'q' to quit:");
                string input = Console.ReadLine();
                
                if (input.ToLower() == "e")
                {
                    trafficLight.HandleEmergency();
                }
                else if (input.ToLower() == "q")
                {
                    Console.WriteLine("Exiting the system.");
                    break;
                }
            }
        }
    }
}
