using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());


            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"ID: {car.Id}\n" +
                    $"Name: {car.Brand} {car.Model} {car.ModelYear} {car.Category}\n" +
                    $"Price: {car.DailyPrice}\n" +
                    $"Description: {car.Description}\n");
            }
        }
    }
}
