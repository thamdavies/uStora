﻿using System;
using System.Collections.Generic;
using uStora.Data.Infrastructure;
using uStora.Data.Repositories;
using uStora.Model.Models;

namespace uStora.Service
{
    public interface IWishlistService
    {
        Wishlist Add(Wishlist wishlist);

        void Update(Wishlist wishlist);

        Wishlist Delete(int id);

        IEnumerable<Wishlist> GetWishlistByUserId(string userId);

        bool CheckContains(long productId);

        IEnumerable<Wishlist> GetAll(string input);

        void SaveChanges();
    }

    public class WishlistService : IWishlistService
    {
        private IWishlistRepository _wishlistRepository;
        private IUnitOfWork _unitOfWork;

        public WishlistService(IWishlistRepository wishlistRepository,
            IUnitOfWork unitOfWork)
        {
            _wishlistRepository = wishlistRepository;
            _unitOfWork = unitOfWork;
        }

        public Wishlist Add(Wishlist wishlist)
        {
            wishlist.Status = true;
            return _wishlistRepository.Add(wishlist);
        }

        public Wishlist Delete(int id)
        {
            return _wishlistRepository.Delete(id);
        }

        public IEnumerable<Wishlist> GetWishlistByUserId(string userId)
        {
            return _wishlistRepository.GetMulti(x => x.UserId == userId);
        }

        public void Update(Wishlist wishlist)
        {
            _wishlistRepository.Update(wishlist);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public bool CheckContains(long productId)
        {
            var res = _wishlistRepository.CheckContains(x => x.ProductId == productId);
            if (res)
                return true;
            else
                return false;
        }

        public IEnumerable<Wishlist> GetAll(string input)
        {
            if (!string.IsNullOrEmpty(input))
                return _wishlistRepository.GetMulti(x => x.Product.Name.Contains(input), new string[] { "Product" });
            else
                return _wishlistRepository.GetAll(new string[] { "Product" });
        }
    }
}