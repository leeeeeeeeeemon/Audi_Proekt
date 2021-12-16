using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audi.Core
{
    class functions
    {
        public static void addCar(string modelT, string nameT, string categoryT, int engPwr, string accel, decimal priceD, string charT)
        {
            var u = new Auto();
            u.model = modelT;
            u.name = nameT;
            u.category = categoryT;
            u.engine_power = engPwr;
            u.acceleration_from_0_to_100_sec____ = accel;
            u.price = priceD;
            u.characteristic = charT;
            bd_connections.connection.Auto.Add(u);
            bd_connections.connection.SaveChanges();
        }
    }

    
}
