﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uStora.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<SlideViewModel> Slides { get; set; }
        public IEnumerable<ProductViewModel> LatestProducts { get; set; }
        public IEnumerable<ProductViewModel> TopSaleProducts { get; set; }
    }
}