using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.DataAccess
{
    public class UserDal
    {
        private static UserDal _Current { get; set; }
        public static UserDal Current
        {
            get
            {
                if (_Current == null)
                {
                    _Current = new UserDal();
                }
                return _Current;
            }
        }

        public List<User> GetUsers()
        {
            string query = "select * from User";

            return DbTools.Connection.ReadUsers(query);
        }

    }
}