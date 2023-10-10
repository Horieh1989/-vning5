namespace övning5
{
    public interface IVehicle
    {
        string color { get; set; }
        string name { get; set; }
        int numberOfWheels { get; set; }
        string registrationNumber { get; set; }
    }
}