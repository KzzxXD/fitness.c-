using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
       

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var birthdate = DateTime.Now.AddYears(-18);
            var gender = "man";
            var weight = 90;
            var height = 190;

            var controller = new UserController(userName);
            controller.SetNewUserData(gender, birthdate, weight, height);
            var controller2 = new UserController(userName);

            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birthdate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            var userName = Guid.NewGuid().ToString();
            var controller = new UserController(userName);


            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}