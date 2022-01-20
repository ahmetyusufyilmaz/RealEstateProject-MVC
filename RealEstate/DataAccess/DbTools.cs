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
        static string strConnection = @"Server=.; Database=DB_Emlak;Trusted_Connection=true;";
        public SqlConnection con = new SqlConnection(strConnection);

        public ResidentialDal residentialDal { get { return new ResidentialDal(); } set { residentialDal = value; } }


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
            SqlCommand cmd;
            object insertedID = -1;
            try
            {
                cmd = new SqlCommand(query, con);
                ConnectDB();
                Console.WriteLine("bağlandı");
                insertedID = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("HATA LOGU Yaz." + ex);
            }
            finally
            {
                DisconnectDB();
            }
            return insertedID;

        }

        public List<AdvertResidential> ReadAdvertResidentials(string query)
        {

            List<AdvertResidential> advertResidentials = new List<AdvertResidential>();
            SqlCommand cmd = new SqlCommand(query, con);
            IDataReader reader;
            try
            {
                ConnectDB();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    advertResidentials.Add(

                        new AdvertResidential
                        {
                            AdvertiseId = int.Parse(reader["AdvertiseId"].ToString()),
                            Date = DateTime.Parse(reader["Date"].ToString()),
                            IsActive = bool.Parse(reader["IsActive"].ToString()),
                            Title = reader["Title"].ToString(),
                            Explaination = reader["Explanation"].ToString(),
                            UserId = int.Parse(reader["UserId"].ToString()),

                            ResidentialId = int.Parse(reader["ResidentialId"].ToString()),
                            AdvertType = (AdvertType)short.Parse(reader["AdvertType"].ToString()),

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
            return advertResidentials;
        }
        public List<AdvertResidential> ReadAdvertices(string query)
        {

            List<AdvertResidential> advertResidentials = new List<AdvertResidential>();
            SqlCommand cmd = new SqlCommand(query, con);
            IDataReader reader;
            try
            {
                ConnectDB();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    advertResidentials.Add(

                        new AdvertResidential
                        {
                            AdvertiseId = Convert.ToInt32(reader["AdvertiseId"].ToString()),
                            Date = DateTime.Parse(reader["Date"].ToString()),
                            IsActive = bool.Parse(reader["IsActive"].ToString()),
                            Title = reader["Title"].ToString(),
                            Explaination = reader["Explanation"].ToString(),
                            UserId = int.Parse(reader["UserId"].ToString()),
                            RealEstate = new Residential
                            {
                                ResidentialId = int.Parse(reader["ResidentialId"].ToString()),
                                SellType = (SellType)Convert.ToInt16(reader["SellType"].ToString()),
                                Msquare = Convert.ToDouble(reader["Msquare"].ToString()),
                                Age = Convert.ToInt16(reader["Age"].ToString()),
                                FloorNumber = byte.Parse(reader["FloorNumber"].ToString()),
                                Heating = (HeatingType)Convert.ToInt16(reader["Heating"].ToString()),
                                Balcony = bool.Parse(reader["Balcony"].ToString()),
                                Furnished = bool.Parse(reader["Furnished"].ToString()),
                                AddressID = int.Parse(reader["AddressID"].ToString()),
                                ResidentalType = (ResidentalType)Convert.ToInt16(reader["ResidentialType"].ToString())
                            },

                            ResidentialId = int.Parse(reader["ResidentialId"].ToString()),
                            AdvertType = (AdvertType)short.Parse(reader["AdvertType"].ToString()),

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
            return advertResidentials;
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
                            ResidentialId = int.Parse(reader["ResidentialId"].ToString()),
                            SellType = (SellType)short.Parse(reader["SellType"].ToString()),
                            Msquare = double.Parse(reader["Msquare"].ToString()),
                            Age = short.Parse(reader["Age"].ToString()),
                            FloorNumber = byte.Parse(reader["FloorNumber"].ToString()),
                            Heating = (HeatingType)short.Parse(reader["Heating"].ToString()),
                            Balcony = bool.Parse(reader["Balcony"].ToString()),
                            Furnished = bool.Parse(reader["Furnished"].ToString()),
                            AddressID = int.Parse(reader["AddressID"].ToString()),
                            ResidentalType = (ResidentalType)short.Parse(reader["ResidentialType"].ToString()),
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
                            ResidentialId = int.Parse(reader["ResidentialId"].ToString()),
                            SellType = (SellType)short.Parse(reader["SellType"].ToString()),
                            Msquare = double.Parse(reader["Msquare"].ToString()),
                            AddressID = int.Parse(reader["AddressID"].ToString()),
                            BlockNumber = int.Parse(reader["BlockNumber"].ToString()),
                            ParcelNumber = int.Parse(reader["ParcelNumber"].ToString()),
                            SquarePrice = (int)double.Parse(reader["SquarePrice"].ToString()),
                            ZoningStatus = (ZoningStatus)short.Parse(reader["ZoningStatus"].ToString())

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

        public List<Commercial> ReadCommercials(string query)
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
                            ResidentialId = int.Parse(reader["ResidentialId"].ToString()),
                            SellType = (SellType)short.Parse(reader["SellType"].ToString()),
                            Msquare = double.Parse(reader["Msquare"].ToString()),
                            Age = short.Parse(reader["Age"].ToString()),
                            FloorNumber = byte.Parse(reader["FloorNumber"].ToString()),
                            Heating = (HeatingType)short.Parse(reader["Heating"].ToString()),
                            Balcony = bool.Parse(reader["Balcony"].ToString()),
                            Furnished = bool.Parse(reader["Furnished"].ToString()),
                            AddressID = int.Parse(reader["AddressID"].ToString()),
                            BuildingType = (BuildingType)short.Parse(reader["BuildingType"].ToString()),


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
    

       