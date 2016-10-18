using MvcPaging;
using System.Collections.Generic;
using uStora.Model.Models;

namespace uStora.Web.Models
{
    public class WishlistViewModel
    {
        public string UserId { get; set; }

        public long ProductId { get; set; }
        
        public virtual ApplicationUserViewModel ApplicationUser { get; set; }
        
        public virtual ProductViewModel Product { get; set; }

        public IPagedList<ProductViewModel> ListProducts { get; set; }
    }
}