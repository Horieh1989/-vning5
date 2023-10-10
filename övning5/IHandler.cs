using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace övning5
{
    public interface IHandler
    {
        Vehicle FindVehicle();
        void ListOfVehicles();
    }
}
