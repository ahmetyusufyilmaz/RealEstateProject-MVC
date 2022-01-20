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

    public enum AdvertType 
    {
    Residential,
    Commercial,
    Land
    }


    public class Residential : IRealEstate
    {

       

        public int ResidentialId { get ; set ; }
        public SellType SellType { get; set; }
        public double Msquare { get; set; }
        public Address Address { get; set; }
        public short Age { get; set; }
        public byte FloorNumber { get; set; }
        public HeatingType Heating { get; set; }
        public bool Balcony { get; set; }
        public bool Furnished { get; set; }
        public ResidentalType ResidentalType { get; set; }
        public int AddressID { get; set; }

        public HttpPostedFileBase Foto { get; set; }
        public string FotoAdres { get; set; }



    }
}