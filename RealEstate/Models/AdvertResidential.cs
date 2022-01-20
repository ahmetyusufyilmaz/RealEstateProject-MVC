using RealEstate.ModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.Models
{
    public class AdvertResidential : IAdvert
    {
        public int AdvertiseId { get ; set ; }
        public DateTime Date { get ; set ; }
        public bool IsActive { get ; set ; }
        public string Title { get ; set ; }
        public string Explaination { get ; set ; }
        public User User { get ; set ; }
        public int UserId { get; set; }
        public Residential RealEstate { get ; set ; }
        public int ResidentialId { get; set; }
        public AdvertType AdvertType { get; set; }



        
        
    }
}