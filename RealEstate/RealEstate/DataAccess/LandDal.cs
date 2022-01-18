using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.DataAccess
{
    public class LandDal
    {
        private static LandDal _Current { get; set; }
        public static LandDal Current
        {
            get
            {
                if (_Current == null)
                {
                    _Current = new LandDal();
                }
                return _Current;
            }
        }
        public object Create(Land land)
        {
            string query = $"Insert into Land (RealEstateId,ResidentalType,SellType,Square,Address,Age,FloorNumber,Heating,Balcony,Furnished) VALUES  ('{residential.RealEstateId}','{residential.ResidentalType}','{residential.SellType}','{residential.Square}','{residential.Address}','{residential.Age}','{residential.FloorNumber}','{residential.Heating}','{residential.Balcony}','{residential.Furnished}');select CAST(scope_identity() as int);";
            object insertedsId = DbTools.Connection.Create(query);
            return insertedsId;
        }
        public List<Land> GetResidential()
        {
            string query = "select * from Land";

            return DbTools.Connection.ReadLand(query);
        }
        public Land GetResidentialById(int id)
        {
            string query = $"select * from Land where ID ={id};";
            return DbTools.Connection.ReadLand(query)[0];
        }
        public bool Update(Land land)
        {
            string query = $"Update Land set RealEstateID='{land.RealEstateId}',SellType='{residential.SellType}', Square='{residential.Square}',Age='{residential.RealEstateId}',FloorNumber='{residential.FloorNumber}',Heating='{residential.Heating}',Balcony='{residential.Balcony}',Furnished='{residential.Furnished}',ResidentialType='{residential.ResidentalType}',AddressID='{residential.AddressID}', where AddressID='{residential.AddressID}';";
            return DbTools.Connection.Execute(query);
        }
        public bool Delete(Land land)
        {
            string query = $"Delete from Land where Id ={residential.RealEstateId};";
            return DbTools.Connection.Execute(query);
        }



    }
}


    }
}