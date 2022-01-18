using RealEstate.ModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.Models
{
    public enum ZoningStatus{
        Field,
        Residentially,
        Commerically,
        SpecialUse,
        Industrially,
        ProtectedArea,

    }

    public class Land : IRealEstate
    {
        public int RealEstateId { get ; set ; }
        public SellType SellType { get ; set ; }
        public double Square { get ; set ; }
        public int AddressID { get; set; }
        public Address Address { get ; set ; }
        public int BlockNumber { get; set; }
        public int ParcelNumber { get; set; }
        public int SquarePrice { get; set; }
        public ZoningStatus ZoningStatus { get; set; }
    }
}