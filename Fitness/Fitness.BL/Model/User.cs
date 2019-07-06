using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    public class User
    {
        public string Name { get; }

        public Gender Gender { get; }

        public DateTime BirthDate { get; }

        public double Weight { get; set; }

        public double Height { get; set; }

    }
}
