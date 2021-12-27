using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMSMVCAPP.Models
{
    public class PackageDetails
    {
        public int PackageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Channels { get; set; }
        public int TypeId { get; set; }
    }
}