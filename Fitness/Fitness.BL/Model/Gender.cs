using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    ///Стать  
    ///
    /// </summary>
    public class Gender
    {/// <summary>
    /// Назва
    /// </summary>
        public string Name { get; }

        /// <summary>
        /// Створити нову стать
        /// </summary>
        /// <param name="name"></param>
        public Gender(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Ім'я статі не може бути пустим або null", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
