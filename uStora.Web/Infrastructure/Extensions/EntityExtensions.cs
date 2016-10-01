using uStora.Model.Models;
using uStora.Web.Models;
using System;

namespace uStora.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryViewModel)
        {
            postCategory.ID = postCategoryViewModel.ID;
            postCategory.Name = postCategoryViewModel.Name;
            postCategory.Alias = postCategoryViewModel.Alias;

            postCategory.Description = postCategoryViewModel.Description;
            postCategory.ParentID = postCategoryViewModel.ParentID;
            postCategory.DisplayOrder = postCategoryViewModel.DisplayOrder;
            postCategory.HomeFlag = postCategoryViewModel.HomeFlag;
            postCategory.Image = postCategoryViewModel.Image;

            postCategory.CreatedDate = postCategoryViewModel.CreatedDate;
            postCategory.CreatedBy = postCategoryViewModel.CreatedBy;
            postCategory.UpdatedDate = postCategoryViewModel.UpdatedDate;
            postCategory.UpdatedBy = postCategoryViewModel.UpdatedBy;
            postCategory.MetaDescription = postCategoryViewModel.MetaDescription;
            postCategory.MetaKeyword = postCategoryViewModel.MetaKeyword;
            postCategory.Status = postCategoryViewModel.Status;
        }

        public static void UpdatePost(this Post post, PostViewModel postViewModel)
        {
            post.ID = postViewModel.ID;
            post.Name = postViewModel.Name;
            post.Alias = postViewModel.Alias;

            post.Description = postViewModel.Description;
            post.CategoryID = postViewModel.CategoryID;
            post.HotFlag = postViewModel.HotFlag;
            post.HomeFlag = postViewModel.HomeFlag;
            post.Image = postViewModel.Image;
            post.ViewCount = postViewModel.ViewCount;
            post.Content = postViewModel.Content;

            post.MetaKeyword = postViewModel.MetaKeyword;
            post.MetaDescription = postViewModel.MetaDescription;
            post.Status = postViewModel.Status;
            post.CreatedDate = postViewModel.CreatedDate;
            post.CreatedBy = postViewModel.CreatedBy;
            post.UpdatedDate = postViewModel.UpdatedDate;
            post.UpdatedBy = postViewModel.UpdatedBy;
        }

        public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryViewModel)
        {
            productCategory.ID = productCategoryViewModel.ID;
            productCategory.Name = productCategoryViewModel.Name;
            productCategory.Alias = productCategoryViewModel.Alias;

            productCategory.Description = productCategoryViewModel.Description;
            productCategory.ParentID = productCategoryViewModel.ParentID;
            productCategory.DisplayOrder = productCategoryViewModel.DisplayOrder;
            productCategory.HomeFlag = productCategoryViewModel.HomeFlag;
            productCategory.Image = productCategoryViewModel.Image;

            productCategory.CreatedDate = productCategoryViewModel.CreatedDate;
            productCategory.CreatedBy = productCategoryViewModel.CreatedBy;
            productCategory.UpdatedDate = productCategoryViewModel.UpdatedDate;
            productCategory.UpdatedBy = productCategoryViewModel.UpdatedBy;
            productCategory.MetaDescription = productCategoryViewModel.MetaDescription;
            productCategory.MetaKeyword = productCategoryViewModel.MetaKeyword;
            productCategory.Status = productCategoryViewModel.Status;
        }

        public static void UpdateProduct(this Product product, ProductViewModel productViewModel)
        {
            product.ID = productViewModel.ID;
            product.Name = productViewModel.Name;
            product.Alias = productViewModel.Alias;

            product.Description = productViewModel.Description;
            product.CategoryID = productViewModel.CategoryID;
            product.Image = productViewModel.Image;
            product.MoreImages = productViewModel.MoreImages;
            product.HomeFlag = productViewModel.HomeFlag;
            product.HotFlag = productViewModel.HotFlag;
            product.Price = productViewModel.Price;
            product.PromotionPrice = productViewModel.PromotionPrice;
            product.Warranty = productViewModel.Warranty;
            product.Content = productViewModel.Content;
            product.ViewCount = productViewModel.ViewCount;
            product.Tags = productViewModel.Tags;
            product.Quantity = productViewModel.Quantity;

            product.CreatedDate = productViewModel.CreatedDate;
            product.CreatedBy = productViewModel.CreatedBy;
            product.UpdatedDate = productViewModel.UpdatedDate;
            product.UpdatedBy = productViewModel.UpdatedBy;
            product.MetaDescription = productViewModel.MetaDescription;
            product.MetaKeyword = productViewModel.MetaKeyword;
            product.Status = productViewModel.Status;
        }

        public static void UpdateFeedback(this Feedback feedback, FeedbackViewModel feedbackViewModel)
        {
            feedback.ID = feedbackViewModel.ID;
            feedback.Name = feedbackViewModel.Name;
            feedback.Email = feedbackViewModel.Email;
            feedback.Message = feedbackViewModel.Message;
            feedback.CreatedDate = DateTime.Now;
            feedback.Status = feedbackViewModel.Status;
        }
    }
}