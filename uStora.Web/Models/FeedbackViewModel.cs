using System;
using System.ComponentModel.DataAnnotations;

namespace uStora.Web.Models
{
    public class FeedbackViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập tên")]
        [MaxLength(50, ErrorMessage = "Tên không quá 50 ký tự")]
        public string Name { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email chưa ký tự không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập nội dung tin nhắn")]
        public string Message { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Required(ErrorMessage="Bạn chưa chọn trạng thái gửi phản hồi")]
        public bool Status { get; set; }

        public ContactDetailViewModel ContactDetail { get; set; }

    }
}