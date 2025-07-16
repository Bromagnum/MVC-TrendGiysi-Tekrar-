using System.ComponentModel.DataAnnotations;

namespace MVC_TrendGiysi_Tekrar_.Models.ViewModel
{
    public class RegisterVM
    {
        



        [Required(ErrorMessage = "kullanıcı adı girilmesi zorunlu!")]
        public string Username { get; set; }




        [Required(ErrorMessage = "email girilmesi zorunlu!")]
        [EmailAddress(ErrorMessage = "lütfen email formatın değer girin")]

        public string Email { get; set; }




        [Required(ErrorMessage = "şifre girilmesi zorunlu!")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }
    }
}
