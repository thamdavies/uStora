using System.Collections.Generic;
using uStora.Data.Infrastructure;
using uStora.Data.Repositories;
using uStora.Model.Models;

namespace uStora.Service
{
    public interface IBrandService
    {
        Brand Add(Brand brand);

        void Update(Brand id);

        Brand Delete(int id);

        void SaveChanges();

        Brand GetByID(int id);

        IEnumerable<Brand> GetAll(string keyword);
    }

    public class BrandService : IBrandService
    {
        private IBrandRepository _brandRepository;
        private IUnitOfWork _unitOfWork;

        public BrandService(IBrandRepository brandRepository,
            IUnitOfWork unitOfWork)
        {
            this._brandRepository = brandRepository;
            this._unitOfWork = unitOfWork;
        }

        public Brand Add(Brand brand)
        {
            return _brandRepository.Add(brand);
        }

        public Brand Delete(int id)
        {
            return _brandRepository.Delete(id);
        }

        public IEnumerable<Brand> GetAll(string keyword)
        {
            if(!string.IsNullOrEmpty(keyword))
            {
                return _brandRepository.GetMulti(x => x.Status && x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            else
            {
                return _brandRepository.GetMulti(x => x.Status);
            }
        }
        

        public Brand GetByID(int id)
        {
            return _brandRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Brand brand)
        {
            _brandRepository.Update(brand);
        }
    }
}