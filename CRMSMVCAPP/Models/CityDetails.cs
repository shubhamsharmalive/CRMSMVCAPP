using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMSMVCAPP.Models
{
    public class CityDetails
    {
        public int Id { get; set; }

        [Display(Name = "City Name")]
        public string Name { get; set; }

        [Display(Name = "Select Country")]
        public string SelectCountry { get; set; }

        public SelectList CoutryList
        {
            get; set;
        }
    }

    public class ValueNamePair
    {
        public string Value { get; set; }
        public string Name { get; set; }

    }
}