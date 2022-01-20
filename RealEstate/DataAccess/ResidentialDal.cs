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
            string query = $"Insert into Residential (RealEstateId,ResidentalType,SellType,Square,Address,Age,FloorNumber,Heating,Balcony,Furnished,FotoAdres) VALUES  ('{residential.ResidentialId}'," +
                $"'{residential.ResidentalType}','{residential.SellType}','{residential.Msquare}','{residential.Address}','{residential.Age}','{residential.FloorNumber}'," +
                $"'{residential.Heating}','{residential.Balcony}','{residential.Furnished}','{residential.FotoAdres}');select CAST(scope_identity() as int);";
            object insertedsId = DbTools.Connection.Create(query);
            return insertedsId;
        }
        public List<Residential> GetResidential()
        {
            string query = "select * from Residential";

            return DbTools.Connection.ReadResidentials(query);
        }
        public Residential GetResidentialById(int id)
        {
            string query = $"select * from Residential where ID ={id};";
            return DbTools.Connection.ReadResidentials(query)[0];
        }
        public bool Update(Residential residential)
        {
            string query = $"Update Residential set RealEstateID='{residential.ResidentialId}',SellType='{residential.SellType}', Square='{residential.Msquare}',Age='{residential.ResidentialId}',FloorNumber='{residential.FloorNumber}',Heating='{residential.Heating}',Balcony='{residential.Balcony}',Furnished='{residential.Furnished}',ResidentialType='{residential.ResidentalType}',AddressID='{residential.AddressID}',FotoAdres='{residential.FotoAdres}' where AddressID='{residential.AddressID}';";
            return DbTools.Connection.Execute(query);
        }
        public bool Delete(Residential residential)
        {
            string query = $"Delete from Residential where Id ={residential.ResidentialId};";
            return DbTools.Connection.Execute(query);
        }



    }
}