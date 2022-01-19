using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.DataAccess
{
    public class CommercialDal
    {


            private static CommercialDal _Current { get; set; }
            public static CommercialDal Current
            {
                get
                {
                    if (_Current == null)
                    {
                        _Current = new CommercialDal();
                    }
                    return _Current;
                }
            }
        public object Create(Commercial commercial)
        {
            string query = $"Insert into Commercial (RealEstateId,ResidentalType,SellType,Square,AddressID,Age,FloorNumber,Heating,Balcony,Furnished,BuildingType) VALUES  ('{commercial.ResidentialId}'," +
                $"'{commercial.ResidentalType}','{commercial.SellType}','{commercial.Msquare}','{commercial.AddressID}','{commercial.Age}','{commercial.FloorNumber}'," +
                $"'{commercial.Heating}','{commercial.Balcony}','{commercial.Furnished}','{commercial.BuildingType}');select CAST(scope_identity() as int);";
            object insertedsId = DbTools.Connection.Create(query);
            return insertedsId;
        }
        public List<Commercial> GetCommercials()
            {
                string query = "select * from Commercial";

                return DbTools.Connection.ReadCommercials(query);
            }
            public Commercial GetCommercialById(int id)
            {
                string query = $"select * from Commercial where ID ={id};";
                return DbTools.Connection.ReadCommercials(query)[0];
            }
        public bool Update(Commercial commercial)
        {
            string query = $"Update Commercial set RealEstateID='{commercial.ResidentialId}',SellType='{commercial.SellType}', Square='{commercial.Msquare}',Age='{commercial.Age}',FloorNumber='{commercial.FloorNumber}',Heating='{commercial.Heating}',Balcony='{commercial.Balcony}',Furnished='{commercial.Furnished}',ResidentialType='{commercial.BuildingType}',AddressID='{commercial.AddressID}', where AddressID='{commercial.AddressID}';";
            return DbTools.Connection.Execute(query);
        }
        public bool Delete(Commercial commercial)
            {
                string query = $"Delete from Commercial where Id ={commercial.ResidentialId};";
                return DbTools.Connection.Execute(query);
            }



        }
    }


