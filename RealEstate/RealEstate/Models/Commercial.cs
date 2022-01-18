using RealEstate.ModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.Models
{
    public enum BuildingType
    {
        Store,
        WorkOffice,
        Cafe,
        ManufacturingFacility
    }

    public class Commercial :Residential 
    {
        public BuildingType BuildingType;
    }
}