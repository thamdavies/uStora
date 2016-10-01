using uStora.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uStora.Web.Models
{
    public class ContactDetailViewModel : Auditable
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public double? Lat { get; set; }

        public double? Lng { get; set; }
    }
}