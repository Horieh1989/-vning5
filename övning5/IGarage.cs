namespace övning5
{
    public interface IGarage<T> : IEnumerable<T> where T : Vehicle
    {
      //  IEnumerator<T> GetEnumerator();
        void ListOfVehicles(T Vehicle);
        bool Park(T vehicle);
        void Remove(T vehicle);
        int Totalpark(T Vehicle);
    }


    //public class DataBaseGarage<T> : IGarage<T> where T : Vehicle
    //{
    //    public IEnumerator<T> GetEnumerator()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void ListOfVehicles(T Vehicle)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool Park(T vehicle)
    //    {
    //        //Saves to database
    //        return false;
    //    }

    //    public void Remove(T vehicle)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int Totalpark(T Vehicle)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}