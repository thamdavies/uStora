using MvcPaging;
using System;

namespace uStora.Web.Models
{
    [Serializable]
    public class WishlistViewModel
    {
        public string UserId { get; set; }

        public long ProductId { get; set; }

        public virtual ApplicationUserViewModel ApplicationUser { get; set; }

        public virtual ProductViewModel Product { get; set; }

        public IPagedList<ProductViewModel> ListProducts { get; set; }
    }
}