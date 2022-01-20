using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.DataAccess
{
    public class AdvertResidentialDal
    {
        private static AdvertResidentialDal _current { get; set; }
        public static AdvertResidentialDal Current
        {
            get
            {

                return _current;
            }
        }
        private ResidentialDal _residentialDal;

        public AdvertResidentialDal(ResidentialDal residentialDal)
        {
            _residentialDal = residentialDal;
        }
        public object Create(AdvertResidential advertResidential)
        {

            int insertedId = Convert.ToInt32(_residentialDal.Create(advertResidential.RealEstate));

            string query = $"insert into Adverts (Date,IsActive,Title,Explanation,UserId, ResidentialId,AdvertType) VALUES " +
                $"('{advertResidential.Date.ToString("MM/dd/yyyy HH:MM")}','{advertResidential.IsActive}','{advertResidential.Title}','{advertResidential.Explaination}','{1}','{insertedId}','{1}');select CAST(scope_identity() as int);";

            object Id = DbTools.Connection.Create(query);
            return Id;
        }

        public List<AdvertResidential> GetAdvertResidentials()
        {
            string query = $"select * from Adverts inner join Residential on Adverts.ResidentialId= Residential.ResidentialId;";


            return DbTools.Connection.ReadAdvertices(query);
        }
        public AdvertResidential GetResidentialById(int id)
        {
            string query = $"select * from Adverts where AdvertiseId ={id};";
            return DbTools.Connection.ReadAdvertResidentials(query)[0];
        }
        public bool Update(AdvertResidential advertResidential)
        {
            int insertedId = Convert.ToInt32(_residentialDal.Update(advertResidential.RealEstate));

            string query = $"Update Adverts set Date='{advertResidential.Date}',IsActive='{advertResidential.IsActive}',Title='{advertResidential.Title}',Explanation='{advertResidential.Explaination}',UserId='{advertResidential.User.Id}', ResidentialId='{ insertedId}',AdvertType='{1}') where Id={advertResidential.AdvertiseId}" +

                $";select CAST(scope_identity() as int);";

            return DbTools.Connection.Execute(query);
        }
        //public bool Delete(AdvertResidential advertResidential)
        //{

        //    _residentialDal.Delete(advertResidential.RealEstate.ResidentialId);
        //    string query = $"Delete from Adverts where AdvertiseId ={advertResidential.AdvertiseId};";
        //    return DbTools.Connection.Execute(query);
        //}
        public List<AdvertResidential> Search(string word)
        {
            string query = $"SELECT * FROM Residential WHERE Title LIKE '%{word}%' OR Explanation LIKE '%{word}';";
            return DbTools.Connection.ReadAdvertResidentials(query);
        }

    }
}