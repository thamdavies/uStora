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

        TrackOrder Delete(int id);

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
