using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.DataAccess
{
    public class ResidentialDal
    {
        private static ResidentialDal _Current { get; set; }
        public static ResidentialDal Current
        {
            get
            {
                if (_Current == null)
                {
                    _Current = new ResidentialDal();
                }
                return _Current;
            }
        }
        public object Create(Residential residential)
        {
            string query = $"Insert into Residental (RealEstateId,ResidentalType,SellType,Square,Address,Age,FloorNumber,Heating,Balcony,Furnished) VALUES  ('{residential.RealEstateId}'," +
                $"'{residential.ResidentalType}','{residential.SellType}','{residential.Square}','{residential.Address}','{residential.Age}','{residential.FloorNumber}'," +
                $"'{residential.Heating}','{residential.Balcony}','{residential.Furnished}');select CAST(scope_identity() as int);";
            object insertedsId = DbTools.Connection.Create(query);
            return insertedsId;
        }
        public List<Residential> GetResidential()
        {
            string query = "select * from Residental";

            return DbTools.Connection.ReadResidentials(query);
        }
        public Residential GetResidentialById(int id)
        {
            string query = $"select * from Residental where ID ={id};";
            return DbTools.Connection.ReadResidentials(query)[0];
        }
        public bool Update(Residential residential)
        {
            string query = $"Update Residental set RealEstateID='{residential.RealEstateId}',SellType='{residential.SellType}', Square='{residential.Square}',Age='{residential.RealEstateId}',FloorNumber='{residential.FloorNumber}',Heating='{residential.Heating}',Balcony='{residential.Balcony}',Furnished='{residential.Furnished}',ResidentialType='{residential.ResidentalType}',AddressID='{residential.AddressID}', where AddressID='{residential.AddressID}';";
            return DbTools.Connection.Execute(query);
        }
        public bool Delete(Residential residential)
        {
            string query = $"Delete from Residental where Id ={residential.RealEstateId};";
            return DbTools.Connection.Execute(query);
        }



    }
}