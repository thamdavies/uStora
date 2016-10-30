using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uStora.Data.Infrastructure;
using uStora.Data.Repositories;
using uStora.Model.Models;

namespace uStora.Service
{
    public interface ITrackOrderService
    {
        TrackOrder Add(TrackOrder trackOrder);

        void Update(TrackOrder trackOrder);

        IEnumerable<TrackOrder> GetAll(string keyword);

        IEnumerable<TrackOrder> GetAll();

        TrackOrder Delete(int id);

        TrackOrder GetById(int id);

        void SaveChanges();
    }
    public class TrackOrderService : ITrackOrderService
    {
        private ITrackOrderRepository _trackOrderRepository;
        private IUnitOfWork _unitOfWork;
        public TrackOrderService(ITrackOrderRepository trackOrderRepository,
           IUnitOfWork unitOfWork)
        {
            _trackOrderRepository = trackOrderRepository;
            _unitOfWork = unitOfWork;
        }

        public TrackOrder Add(TrackOrder trackOrder)
        {
            return _trackOrderRepository.Add(trackOrder);
        }

        public TrackOrder Delete(int id)
        {
            return _trackOrderRepository.Delete(id);
        }

        public IEnumerable<TrackOrder> GetAll()
        {
            return _trackOrderRepository.GetAll(new string[] { "Order", "ApplicationUser", "Vehicle" });
        }

        public IEnumerable<TrackOrder> GetAll(string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword))
                {
                    return _trackOrderRepository.GetAll(new string[] { "Order", "ApplicationUser", "Vehicle" }).OrderByDescending(x=>x.Status);
                }
                else
                    return _trackOrderRepository.GetMulti(x => x.Order.CustomerName.Contains(keyword)
                    || x.Vehicle.DriverName.Contains(keyword) || x.Order.CreatedDate.ToString().Contains(keyword),
                    new string[] { "Order", "ApplicationUser", "Vehicle" }).OrderByDescending(x => x.Status);
            }
            catch
            {
                throw;
            }
        }

        public TrackOrder GetById(int id)
        {
            return _trackOrderRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(TrackOrder trackOrder)
        {
            _trackOrderRepository.Update(trackOrder);
        }
    }
}
