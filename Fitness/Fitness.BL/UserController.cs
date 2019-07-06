using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL
{
    /// <summary>
    /// Контроллер користувача
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Користувач
        /// </summary>
        public User User { get; }
       /// <summary>
       /// Ствоорення нового користувача
       /// </summary>
       /// <param name="user"></param>
        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height )
        {
            //TODO: провірка
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDate, weight, height);
        }

        /// <summary>
        /// Отримати дані користувача
        /// </summary>
        /// <returns></returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
               if(formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
               //TODO: що робити в тому випадку, якщо користувача не прочитали
            }

        }


        /// <summary>
        /// Зберегти дані користувача
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
          
            }
        }
        
    }
}
