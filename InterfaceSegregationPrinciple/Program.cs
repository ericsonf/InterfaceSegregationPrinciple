using System;
using Microsoft.Extensions.DependencyInjection;

namespace InterfaceSegregationPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            // Código inserido para utilizar injeção de dependência dentro de uma aplicação Console Application.
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IBird, Bird>()
                .AddSingleton<IDog, Dog>()
                .AddSingleton<IMutant, Mutant>()
                .BuildServiceProvider();

            var bird = serviceProvider.GetService<IBird>();
            bird.Fly();

            var dog = serviceProvider.GetService<IDog>();
            dog.Howl();

            var mutant = serviceProvider.GetService<IMutant>();
            mutant.Fly();
            mutant.Howl();
        }
    }

    public interface IBird
    {
        void Fly();
    }
    public interface IDog
    {
        void Howl();
    }

    public interface IMutant : IBird, IDog
    {
    }

    public class Bird : IBird
    {
        public void Fly()
        {
            Console.WriteLine("Flying!!!");
        }
    }

    public class Dog : IDog
    {
        public void Howl()
        {
            Console.WriteLine("Howling!!!");
        }
    }

    public class Mutant : IMutant
    {
        private readonly IBird _bird;
        private readonly IDog _dog;

        public Mutant(IBird bird, IDog dog)
        {
            _bird = bird;
            _dog = dog;
        }

        public void Fly()
        {
            _bird.Fly();
        }

        public void Howl()
        {
            _dog.Howl();
        }
    }
}
