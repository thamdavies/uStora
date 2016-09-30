using uStora.Data.Infrastructure;
using uStora.Data.Repositories;
using uStora.Model.Models;

namespace uStora.Service
{
    public interface IFeedbackService
    {
        Feedback Create(Feedback feedback);
        void SaveChanges();
    }

    public class FeedbackService : IFeedbackService
    {
        private IFeedbackRepository _feedbackRepository;
        private IUnitOfWork _unitOfWork;

        public FeedbackService(IFeedbackRepository feedbackRepository, IUnitOfWork unitOfWork)
        {
            this._feedbackRepository = feedbackRepository;
            this._unitOfWork = unitOfWork;
        }

        public Feedback Create(Feedback feedback)
        {
            feedback.Status = true;
            return _feedbackRepository.Add(feedback);
        }


        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}