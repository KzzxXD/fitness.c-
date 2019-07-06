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
        public List<User> Users { get; }
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;
        /// <summary>
       /// Ствоорення нового користувача
       /// </summary>
       /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Ім'я користувача не може бути пустим", nameof(userName));
            }

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

        }


        public void SetNewUserData(string genderName, DateTime birthDate, double weight =1, double height = 1 )
        {
            //TODO: Перевірка
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();

        }

        /// <summary>
        /// Отримати збрежений список користувачів
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> user)
                {
                    return user;
                }
                else
                {
                    return new List<User>();
                }
            }
            return null;
        }


        /// <summary>
        /// Зберегти дані користувача
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
          
            }
        }
        
    }
}
