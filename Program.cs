using System;

namespace SolidDesignPrinciple
{
    internal class Program
    {
        // ============================================
        // 1. Single Responsibility Principle (SRP)
        // ============================================

        // Before SRP: The class has multiple responsibilities
        public class Report
        {
            public void GenerateReports() { }
            public void SaveIntoFile() { }
        }

        // After SRP: We separate responsibilities into different classes
        public class ReportGenerator
        {
            public void GenerateReports() { }
        }

        public class ReportSaver
        {
            public void SaveIntoFile() { }
        }

        // ============================================
        // 2. Open/Closed Principle (OCP)
        // ============================================

        // Before OCP: Adding new shapes requires modifying the AreaCalculator class
        public class Rectangle
        {
            public double Width { get; set; }
            public double Height { get; set; }
        }

        public class AreaCalculator
        {
            public double CalculateArea(Rectangle rectangle)
            {
                return rectangle.Width * rectangle.Height;
            }
        }

        // After OCP: We add new shapes without modifying existing code
        public interface IShape
        {
            double CalculateArea();
        }

        public class Rectangle : IShape
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public double CalculateArea()
            {
                return Width * Height;
            }
        }

        public class Circle : IShape
        {
            public double Radius { get; set; }
            public double CalculateArea()
            {
                return Math.PI * Radius * Radius;
            }
        }

        // ============================================
        // 3. Liskov Substitution Principle (LSP)
        // ============================================

        // Before LSP: Derived class cannot be used as a substitute for the base class
        public class Bird
        {
            public virtual void Fly() { Console.WriteLine("Flying!"); }
        }

        public class Penguin : Bird
        {
            public override void Fly()
            {
                throw new NotImplementedException("Penguins can't fly!");
            }
        }

        // After LSP: Derived class does not break base class behavior
        public interface IFlyable
        {
            void Fly();
        }

        public class Bird : IFlyable
        {
            public void Fly() { Console.WriteLine("Flying!"); }
        }

        public class Penguin : IFlyable
        {
            public void Fly()
            {
                Console.WriteLine("Penguins can't fly, so this method does nothing.");
            }
        }

        // ============================================
        // 4. Interface Segregation Principle (ISP)
        // ============================================

        // Before ISP: A class is forced to implement methods it doesn't need
        public interface IWorker
        {
            void Work();
            void Eat();
        }

        public class Manager : IWorker
        {
            public void Work() { Console.WriteLine("Managing!"); }
            public void Eat() { Console.WriteLine("Eating!"); }
        }

        public class Robot : IWorker
        {
            public void Work() { Console.WriteLine("Working!"); }
            public void Eat() { throw new NotImplementedException("Robots can't eat!"); }
        }

        // After ISP: We split the interfaces into smaller, more specific ones
        public interface IWorkable
        {
            void Work();
        }

        public interface IEatable
        {
            void Eat();
        }

        public class Manager : IWorkable, IEatable
        {
            public void Work() { Console.WriteLine("Managing!"); }
            public void Eat() { Console.WriteLine("Eating!"); }
        }

        public class Robot : IWorkable
        {
            public void Work() { Console.WriteLine("Working!"); }
        }

        // ============================================
        // 5. Dependency Inversion Principle (DIP)
        // ============================================

        // Before DIP: High-level modules depend on low-level modules
        public class LightBulb
        {
            public void TurnOn() { Console.WriteLine("Light is On!"); }
            public void TurnOff() { Console.WriteLine("Light is Off!"); }
        }

        public class Switch
        {
            private LightBulb bulb;

            public Switch(LightBulb bulb)
            {
                this.bulb = bulb;
            }

            public void Toggle()
            {
                Console.WriteLine("Toggling the switch.");
                bulb.TurnOn();
            }
        }

        // After DIP: High-level modules depend on abstractions
        public interface ISwitchable
        {
            void TurnOn();
            void TurnOff();
        }

        public class LightBulb : ISwitchable
        {
            public void TurnOn() { Console.WriteLine("Light is On!"); }
            public void TurnOff() { Console.WriteLine("Light is Off!"); }
        }

        public class Switch
        {
            private ISwitchable device;

            public Switch(ISwitchable device)
            {
                this.device = device;
            }

            public void Toggle()
            {
                Console.WriteLine("Toggling the switch.");
                device.TurnOn();
            }
        }

        public static void Main(string[] args)
        {
            //
        }
    }
}
