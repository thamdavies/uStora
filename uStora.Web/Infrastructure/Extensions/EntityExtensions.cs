﻿using uStora.Model.Models;
using uStora.Web.Models;
using System;
using System.Collections.Generic;

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
            product.BrandID = productViewModel.BrandID;
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

        public static void UpdateSlide(this Slide slide, SlideViewModel slideViewModel)
        {
            slide.ID = slideViewModel.ID;
            slide.Name = slideViewModel.Name;

            slide.Description = slideViewModel.Description;
            slide.Image = slideViewModel.Image;
            slide.Content = slideViewModel.Content;
            slide.URL = slideViewModel.URL;
            slide.DisplayOrder = slideViewModel.DisplayOrder;

            slide.CreatedDate = slideViewModel.CreatedDate;
            slide.CreatedBy = slideViewModel.CreatedBy;
            slide.UpdatedDate = slideViewModel.UpdatedDate;
            slide.UpdatedBy = slideViewModel.UpdatedBy;
            slide.MetaDescription = slideViewModel.MetaDescription;
            slide.MetaKeyword = slideViewModel.MetaKeyword;
            slide.Status = slideViewModel.Status;
        }

        public static void UpdateBrand(this Brand brand, BrandViewModel brandViewModel)
        {
            brand.ID = brandViewModel.ID;
            brand.Name = brandViewModel.Name;

            brand.Description = brandViewModel.Description;
            brand.Image = brandViewModel.Image;
            brand.Alias = brandViewModel.Alias;
            brand.Country = brandViewModel.Country;
            brand.Website = brandViewModel.Website;
            brand.HotFlag = brandViewModel.HotFlag;

            brand.CreatedDate = brandViewModel.CreatedDate;
            brand.CreatedBy = brandViewModel.CreatedBy;
            brand.UpdatedDate = brandViewModel.UpdatedDate;
            brand.UpdatedBy = brandViewModel.UpdatedBy;
            brand.MetaDescription = brandViewModel.MetaDescription;
            brand.MetaKeyword = brandViewModel.MetaKeyword;
            brand.Status = brandViewModel.Status;
        }

        public static void UpdateFeedback(this Feedback feedback, FeedbackViewModel feedbackViewModel)
        {
            feedback.ID = feedbackViewModel.ID;
            feedback.Name = feedbackViewModel.Name;
            feedback.Email = feedbackViewModel.Email;
            feedback.Message = feedbackViewModel.Message;
            feedback.Address = feedbackViewModel.Address;
            feedback.Phone = feedbackViewModel.Phone;
            feedback.Website = feedbackViewModel.Website;
            feedback.CreatedDate = DateTime.Now;
            feedback.Status = feedbackViewModel.Status;
        }
        public static void UpdateOrder(this Order order, OrderViewModel orderViewModel)
        {
            order.ID = orderViewModel.ID;
            order.CustomerName = orderViewModel.CustomerName;
            order.CustomerEmail = orderViewModel.CustomerEmail;
            order.CustomerAddress = orderViewModel.CustomerAddress;
            order.CustomerMobile = orderViewModel.CustomerMobile;
            order.PaymentMethod = orderViewModel.PaymentMethod;
            order.PaymentStatus = orderViewModel.PaymentStatus;
            order.CustomerMessage = orderViewModel.CustomerMessage;
            order.CustomerId = orderViewModel.CustomerId;
            order.CreatedDate = DateTime.Now;
            order.CreatedBy = orderViewModel.CreatedBy;
            order.Status = orderViewModel.Status;
        }
        public static void UpdateApplicationGroup(this ApplicationGroup appGroup, ApplicationGroupViewModel appGroupViewModel)
        {
            appGroup.ID = appGroupViewModel.ID;
            appGroup.Name = appGroupViewModel.Name;
            appGroup.Description = appGroupViewModel.Description;
        }

        public static void UpdateApplicationRole(this ApplicationRole appRole, ApplicationRoleViewModel appRoleViewModel, string action = "add")
        {
            if (action == "update")
                appRole.Id = appRoleViewModel.Id;
            else
                appRole.Id = Guid.NewGuid().ToString();
            appRole.Name = appRoleViewModel.Name;
            appRole.Description = appRoleViewModel.Description;
        }
        public static void UpdateUser(this ApplicationUser appUser, ApplicationUserViewModel appUserViewModel, string action = "add")
        {
            appUser.Id = appUserViewModel.Id;
            appUser.FullName = appUserViewModel.FullName;
            appUser.BirthDay = appUserViewModel.BirthDay;
            appUser.Email = appUserViewModel.Email;
            appUser.Image = appUserViewModel.Image;
            appUser.UserName = appUserViewModel.UserName;
            appUser.PhoneNumber = appUserViewModel.PhoneNumber;
            appUser.Gender = appUserViewModel.Gender;
        }
    }
}