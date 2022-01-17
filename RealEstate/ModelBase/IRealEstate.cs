using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.ModelBase
{
    public enum SellType
    {
        ForSale,
        ForRent
    }

    public interface IRealEstate
    {
        int ID { get; set; }
        SellType SellType { get; set; }
        double Square { get; set; }
        Address Address { get; set; }

        
    }
}
