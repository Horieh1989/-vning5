using övning5;

namespace VehicleTest
{
    public class Vehicle
    {
        [SetUp]
        public void Get_Car_Ans_Park()
        {
            //Arrange
            var garage = new Garage<Vehicle>(5);
            Vehicle vehcle = new Vehicle();
          
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}