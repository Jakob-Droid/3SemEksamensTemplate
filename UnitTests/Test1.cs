using System;
using ModelLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class Test1
    {
        private Car _testCar;

        [TestInitialize]
        public void TestInitialize()
        {
            _testCar= new Car()
            {
                Color = "Blue",
                Name = "Ford",
                RegNo = "12345678"
            };
        }
        [TestMethod()]
        public void CarTestRegNo()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _testCar.RegNo = "1234567");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _testCar.RegNo = "123456789");
            try
            {
                _testCar.RegNo = "12345678";
            }
            catch (Exception e)
            {
                Assert.Fail();
            }

            
        }
    }
}
