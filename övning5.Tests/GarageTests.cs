namespace övning5.Tests
{
    public class GarageTests
    {
        [Fact]
        public void Constructor_ShouldThrowException_WhenNegativeCapacity()
        {
            Assert.Throws<OverflowException>(() =>  new Garage<Vehicle>(-2));
        } 
        
        
        [Fact]
        public void Constructor_ShouldCreateGarage_WithCorrectCapacity()
        {
            var garage = new Garage<Vehicle>(10);
        }
    }
}