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
            /*
                        Console.WriteLine("Введіть стать");
                        var gender = Console.ReadLine();


                        Console.WriteLine("Введіть дату народження");
                        var birthDate = DateTime.Parse(Console.ReadLine());//TODO: TryParse
                        Console.WriteLine("Введіть вагу");
                        var weight = double.Parse(Console.ReadLine());

                        Console.WriteLine("Введіть Ріст");
                        var height = double.Parse(Console.ReadLine());
                        */
            var userController = new UserController(name);


            Console.WriteLine(userController.CurrentUser);

            if (userController.IsNewUser)
            {



                Console.WriteLine("Введіть стать");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("вага");
                var height = ParseDouble("ріст");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.ReadLine();
           
           
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Введіть дату народження");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Введіть кореткні дані!");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введіть {name}");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                    
                }
                else
                {
                    Console.WriteLine($"Не вірний формат {name}");
                }
            }
        }
    }
}
