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
    public class UserController
    {
        public User User { get; }

        public UserController(User user)
        {
            User = user ?? throw new ArgumentNullException("Користувач не може бути рівним null",nameof(user));
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
        /// <summary>
        /// Отримати дані користувача
        /// </summary>
        /// <returns></returns>
        public User Load()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {

                if (formatter.Deserialize(fs) is User user)
                {
                    return user;
                }
                else
                {
                    throw new FileLoadException("Не вдалось отримати дані з файлу", "users");
                }


            }

        }

    }
}
