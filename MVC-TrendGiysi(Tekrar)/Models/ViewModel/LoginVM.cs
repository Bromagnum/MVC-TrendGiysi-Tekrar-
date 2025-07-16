using System.ComponentModel.DataAnnotations;

namespace MVC_TrendGiysi_Tekrar_.Models.ViewModel
{
    public class LoginVM
    {

        [Required(ErrorMessage = "kullanıcı adı girilmesi zorunlu!")]
        public string Username { get; set; }


        [Required(ErrorMessage = "şifre girilmesi zorunlu!")]
        public string Password { get; set; }
    }
}
