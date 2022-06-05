using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMSMVCAPP.Models
{
    public class CityDetails
    {
        public int Id { get; set; }

        [Display(Name = "City Name")]
        public string Name { get; set; }
    }
}