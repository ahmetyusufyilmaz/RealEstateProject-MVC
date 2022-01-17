using RealEstate.ModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.Models
{

    public enum HeatingType
    {
        NaturalGas,
        AirConditioning,
        Stove,
        CentralHeating
    }
    public enum ResidentalType
    {
        Flat,
        Residence,
        Villa,
        FarmHouse
    }

    public class Residential : IRealEstate
    {
        public int ID { get ; set ; }
        public SellType SellType { get; set; }
        public double Square { get; set; }
        public Address Address { get; set; }
        public short Age { get; set; }
        public byte FloorNumber { get; set; }
        public HeatingType Heating { get; set; }
        public bool Balcony { get; set; }
        public bool Furnished { get; set; }
        public ResidentalType ResidentalType { get; set; }



    }
}