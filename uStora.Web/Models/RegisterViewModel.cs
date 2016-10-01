using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace uStora.Web.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Bạn cần nhập họ tên")]
        [MaxLength(50,ErrorMessage="Họ tên không quá 50 ký tự.")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tên đăng nhập")]
        [MaxLength(50, ErrorMessage = "Tên đăng nhập không quá 50 ký tự.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập mật khẩu")]
        [MinLength(6, ErrorMessage = "Mật khẩu ít nhất phải 6 ký tự.")]
        [MaxLength(32, ErrorMessage = "Mật khẩu không quá 32 ký tự.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email chưa ký tự không hợp lệ")]
        public string Email { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập số điện thoại")]
        public string PhoneNumber { get; set; }
    }
}