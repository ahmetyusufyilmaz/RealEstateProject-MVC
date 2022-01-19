using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.DataAccess
{
    public class AdvertResidentialDal
    {
        private static AdvertResidentialDal _Current { get; set; }
        public static AdvertResidentialDal Current
        {
            get
            {

                return _Current;
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

            string query = $"insert into Adverts (Id,PublishDate,IsActive,Title,Explanation,UserId, ResidentialId,AdvertType) VALUES " +
                $"('{advertResidential.Date}','{advertResidential.IsActive}','{advertResidential.Title}','{advertResidential.Explaination}','{advertResidential.User.Id}','{ insertedId}','{1}')" +
                $";select CAST(scope_identity() as int);";
            object insertedsId = DbTools.Connection.Create(query);
            return insertedsId;
        }

        public List<AdvertResidential> GetAdvertResidential()
        {
            string query = $"select * from Adverts where AdvertType={1}";

            return DbTools.Connection.ReadAdvertResidential(query);
        }
        public AdvertResidential GetResidentialById(int id)
        {
            string query = $"select * from Residential where ID ={id};";
            return DbTools.Connection.ReadAdvertResidential(query)[0];
        }
        public bool Update(AdvertResidential advertResidential)
        {
            int insertedId = Convert.ToInt32(_residentialDal.Update(advertResidential.RealEstate));

            string query = $"Update Adverts set PublishDate='{advertResidential.Date}',IsActive='{advertResidential.IsActive}',Title='{advertResidential.Title}',Explanation='{advertResidential.Explaination}',UserId='{advertResidential.User.Id}', ResidentialId='{ insertedId}',AdvertType='{1}') where Id={advertResidential.AdvertiseId}" +

                $";select CAST(scope_identity() as int);";

            return DbTools.Connection.Execute(query);
        }
        //public bool Delete(AdvertResidential advertResidential)
        //{
        //    string query = $"Delete from Residential where Id ={residential.RealEstateId};";
        //    return DbTools.Connection.Execute(query);
        //}



    }
}