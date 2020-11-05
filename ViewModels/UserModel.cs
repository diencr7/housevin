using System;
using System.ComponentModel.DataAnnotations;

namespace HouseVin.ViewModels
{
    public class UserModel
    {
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z''-'\S]{1,40}$",
         ErrorMessage = "Có các ký tự không được phép.")]
        [Display(Name = "Tài khoản")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$",
            ErrorMessage = "Mật khẩu yêu cầu 8 ký tự trở lên, cần có cả chữ viết hoa, viết thường và số")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu và mật khẩu xác nhận không khớp với nhau")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Tài khoản Admin?")]
        public bool Role { get; set; }
    }

}
