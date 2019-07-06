using Fitness.BL;
using Fitness.BL.Model;
using System;
namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привіт в додатку Fitness!");
            Console.WriteLine("Введіть ім'я користувача");
            var name = Console.ReadLine();
            Console.WriteLine("Введіть стать");
            var gender = Console.ReadLine();


            Console.WriteLine("Введіть дату народження");
            var birthDate = DateTime.Parse(Console.ReadLine());//TODO: TryParse
            Console.WriteLine("Введіть вагу");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введіть Ріст");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();


        }
    }
}
