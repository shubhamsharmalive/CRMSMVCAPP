using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMSMVCAPP.Models
{
    public class QRCodeModel
    {
        [Required]
        public string qrcode { get; set; }
    }
}