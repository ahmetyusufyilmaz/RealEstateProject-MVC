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
        int ResidentialId { get; set; }
        SellType SellType { get; set; }
        double Msquare { get; set; }
        Address Address { get; set; }

        
    }
}
