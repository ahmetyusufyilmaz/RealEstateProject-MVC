using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using RealEstate.Models;
using RealEstate.DataAccess;
using System.Configuration;
using RealEstate.ModelBase;

namespace RealEstate.DataAccess
{
    public class DbTools
    {
        static string strConnection = ConfigurationManager.ConnectionStrings["DB_Emlak"].ConnectionString;
       public SqlConnection con = new SqlConnection(strConnection);
        private static DbTools _Con { get; set; }
        public static DbTools Connection
        {
            get
            {
                if (_Con == null)
                    _Con = new DbTools();
                return _Con;
            }
        }
        public bool ConnectDB()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DisconnectDB()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public object Create(string query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            object insertedID = -1;
            try
            {
               ConnectDB();
                insertedID = cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                Console.WriteLine("HATA LOGU Yaz.");
            }
            finally
            {
                DisconnectDB();
            }
            return insertedID;

        }
        public List<Residential> ReadResidentials(string query)
        {
            List<Residential> residentials = new List<Residential>();
            SqlCommand cmd = new SqlCommand(query, con);
            IDataReader reader;
            try
            {
                ConnectDB();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    residentials.Add(
                        new Residential
                        {
                            RealEstateId = int.Parse(reader["Id"].ToString()),
                            SellType= (SellType)short.Parse(reader["SellType"].ToString()),
                            Square=double.Parse(reader["Square"].ToString()),
                            Age= short.Parse(reader["Age"].ToString()),
                            FloorNumber= byte.Parse(reader["FloorNumber"].ToString()),
                            Heating=(HeatingType)short.Parse(reader["Heating"].ToString()),
                            Balcony = bool.Parse(reader["Balcony"].ToString()),
                            Furnished=bool.Parse(reader["Furnished"].ToString()),
                            AddressID =int.Parse(reader["AddressID"].ToString()),
                            ResidentalType=(ResidentalType)short.Parse(reader["ResidentalType"].ToString()),

                        }
                        );
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                DisconnectDB();
            }
            return residentials;
        }

        public List<Land> ReadLand(string query)
        {
            List<Land> lands = new List<Land>();
            SqlCommand cmd = new SqlCommand(query, con);
            IDataReader reader;
            try
            {
                ConnectDB();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lands.Add(
                        new Land
                        {
                            RealEstateId = int.Parse(reader["Id"].ToString()),
                            SellType = (SellType)short.Parse(reader["SellType"].ToString()),
                            Square = double.Parse(reader["Square"].ToString()),
                            AddressID = int.Parse(reader["AddressID"].ToString()),
                            BlockNumber = int.Parse(reader["BlockNumber"].ToString()),
                            ParcelNumber = int.Parse(reader["ParcelNumber"].ToString()),
                            SquarePrice = (int)double.Parse(reader["SquarePrice"].ToString()),
                            ZoningStatus=(ZoningStatus)short.Parse(reader["ZoningStatus"].ToString())

                        });
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                DisconnectDB();

            }
            return lands;
        }

        public List<Commercial> ReadCommerical(string query)
        {
            List<Commercial> commercials = new List<Commercial>();
            SqlCommand cmd = new SqlCommand(query, con);
            IDataReader reader;
            try
            {
                ConnectDB();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    commercials.Add(
                        new Commercial
                        {
                            RealEstateId = int.Parse(reader["Id"].ToString()),
                            SellType = (SellType)short.Parse(reader["SellType"].ToString()),
                            Square = double.Parse(reader["Square"].ToString()),
                            Age = short.Parse(reader["Age"].ToString()),
                            FloorNumber = byte.Parse(reader["FloorNumber"].ToString()),
                            Heating = (HeatingType)short.Parse(reader["Heating"].ToString()),
                            Balcony = bool.Parse(reader["Balcony"].ToString()),
                            Furnished = bool.Parse(reader["Furnished"].ToString()),
                            AddressID = int.Parse(reader["AddressID"].ToString()),
                            BuildingType=(BuildingType)short.Parse(reader["BuildingType"].ToString()),
                           

                        });
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                DisconnectDB();

            }
            return commercials;
        }

        public bool Execute(string query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            int affectedRows = -1;
            try
            {
                ConnectDB();
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                DisconnectDB();
            }
            if (affectedRows > 0)
                return true;
            else
                return false;
        }
    }
}
    

       