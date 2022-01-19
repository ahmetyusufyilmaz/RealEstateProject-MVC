using RealEstate.ModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.Models.ViewModels
{
    public class AdverticeViewModel
    {
        public int AdvertId { get; set; }

        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
        public string Explaination { get; set; }
        public int UserId { get; set; }
        public AdvertType AdvertType { get; set; }
        public int ResidentialId { get; set; }
        public SellType SellType { get; set; }
        public double Msquare { get; set; }
        public short Age { get; set; }
        public short FloorNumber { get; set; }
        public HeatingType Heating { get; set; }
        public bool Balcony { get; set; }
        public bool Furnished { get; set; }
        public BuildingType BuildingType { get; set; }
        public int AddressId { get; set; }

    }
}