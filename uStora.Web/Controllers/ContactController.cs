using AutoMapper;
using BotDetect.Web.Mvc;
using System.Web.Mvc;
using uStora.Common;
using uStora.Model.Models;
using uStora.Service;
using uStora.Web.Infrastructure.Extensions;
using uStora.Web.Models;

namespace uStora.Web.Controllers
{
    public class ContactController : Controller
    {
        private IContactDetailService _contactDetailService;
        private IFeedbackService _feedbackService;

        public ContactController(IContactDetailService contactDetailService, IFeedbackService feedbackService)
        {
            this._contactDetailService = contactDetailService;
            this._feedbackService = feedbackService;
        }

        public ActionResult Index()
        {
            FeedbackViewModel viewModel = new FeedbackViewModel();
            viewModel.ContactDetail = GetContactDetail();
            return View(viewModel);
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "contactCaptcha", "Mã xác nhận không hợp lệ!")]
        public ActionResult SendFeedback(FeedbackViewModel feedbackViewModel)
        {
            if (ModelState.IsValid)
            {
                Feedback feedback = new Feedback();
                feedback.UpdateFeedback(feedbackViewModel);
                _feedbackService.Create(feedback);
                _feedbackService.SaveChanges();

                ViewData["isSuccess"] = "Phản hồi của bạn được gửi thành công";

                string content = System.IO.File.ReadAllText(Server.MapPath("/Assets/client/templates/contactTemplate.html"));
                content = content.Replace("{{Name}}", feedbackViewModel.Name);
                content = content.Replace("{{Email}}", feedbackViewModel.Email);
                content = content.Replace("{{Message}}", feedbackViewModel.Message);
                var adminEmail = ConfigHelper.GetByKey("AdminEmail");
                MailHelper.SendMail(adminEmail, "Thông tin liên hệ từ Website.", content);

                feedbackViewModel.Name = "";
                feedbackViewModel.Email = "";
                feedbackViewModel.Message = "";
            }
            else
            {
                ModelState.AddModelError("", "Thông tin phản hồi chưa hợp lệ");
            }
            feedbackViewModel.ContactDetail = GetContactDetail();
            return View("Index", feedbackViewModel);
        }

        private ContactDetailViewModel GetContactDetail()
        {
            var contact = _contactDetailService.GetDefaultContact();
            var contactVm = Mapper.Map<ContactDetail, ContactDetailViewModel>(contact);
            return contactVm;
        }
    }
}