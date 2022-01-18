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
            string query = $"Insert into Land (RealEstateId,ZoningStatus,SellType,Square,AddressID,BlockNumber,ParcelNumber,SquarePrice) VALUES  ('{land.RealEstateId}','{land.ZoningStatus}','{land.SellType}'," +
                $"'{land.Square}','{land.AddressID}','{land.BlockNumber}','{land.ParcelNumber}','{land.SquarePrice}');select CAST(scope_identity() as int);";
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
            string query = $"Update Land set RealEstateID='{land.RealEstateId}',SellType='{land.SellType}', Square='{land.Square}',AddressID='{land.AddressID}',BlockNumber='{land.BlockNumber}',ParcelNumber='{land.ParcelNumber}',SquarePrice='{land.SquarePrice}',ZoningStatus='{land.ZoningStatus}', where AddressID='{land.AddressID}';";
            return DbTools.Connection.Execute(query);
        }
        public bool Delete(Land land)
        {
            string query = $"Delete from Land where Id ={land.RealEstateId};";
            return DbTools.Connection.Execute(query);
        }



    }
}


 