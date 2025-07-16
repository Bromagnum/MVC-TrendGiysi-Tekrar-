using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_TrendGiysi_Tekrar_.Models.Entities;
using MVC_TrendGiysi_Tekrar_.Models.ViewModel;

namespace MVC_TrendGiysi_Tekrar_.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SignInManager<AppUser> _signInManager { get; }

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        #region Kayıt İşlemi
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {

            if (ModelState.IsValid)//true
            {
                //model içerisinde tanımlanan işlemler sağlanmış mı. eğer model istediğimiz gibi geldiyse bir user oluşturulacak.
                AppUser user = new AppUser
                {
                    UserName = registerVM.Username,
                    Email = registerVM.Email,
                };

                var result = await _userManager.CreateAsync(user, registerVM.ConfirmPassword);
                if (result.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "user");
                    if (roleResult.Succeeded)
                    {

                        TempData["Success"] = "Kayıt oluşturuldu!";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["Success"] = "Role oluşturulamadı!";
                        return View(registerVM);
                    }

                }
                else
                {
                    TempData["Error"] = "bir sorun meydana geldi";
                    return View(registerVM);
                }




            }
            else
            {
                return View(registerVM);
            }

        }
        #endregion


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {

            //todo: kullanıcı giriş result faild dönüyor


            if (ModelState.IsValid)
            {


                AppUser user = await _userManager.FindByNameAsync(loginVM.Username);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }



                return View(loginVM);



            }
            else
            {
                return View(loginVM);
            }
            // return View();
        }


        public IActionResult AccessDenied()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                TempData["Error"] = "kullanıcı bulunamadı!";
                return RedirectToAction("Index", "Home");

            }
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
