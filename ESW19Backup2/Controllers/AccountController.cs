using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ESW19Backup2.Models;
using ESW19Backup2.Models.AccountViewModels;
using ESW19Backup2.Services;
using ESW19Backup2.Data;

namespace ESW19Backup2.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        protected readonly List<Ajuda> _ajudas;
        protected readonly List<Erro> _erros;



        public AccountController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
             ILogger<AccountController> logger)
        {
            _ajudas = context.Ajudas.Where(ai => ai.Controller == "Account").ToList();
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _erros = context.Erros.ToList();

        }

        [TempData]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnUrl">Optional. The default value is null.</param>
        /// <returns name="View do Login"></returns>
        /// <remarks></remarks>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            AjudasLogin();
            SetHelpModal("Login");
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Login com sucesso.");
                    return RedirectToLocal(returnUrl);
                }
                else

                    SetErrorMessage("001");


            }
            else
                SetErrorMessage("002");
            SetHelpModal("Login");
            AjudasLogin();

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            AjudasRegisto();
            SetHelpModal("Register");
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    SetSuccessMessage("Conta criada com sucesso. Note que esta tem que ser ativada no email antes de poder ser utilizada.");
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation("User created a new account with password.");
                    return RedirectToAction("Login");
                }
                else
                {
                    if (result.Errors.Where(r => r.Code == "DuplicateUsername").ToList().Count != 0)
                    {
                        SetErrorMessage("004");
                    }
                    else
                    {
                        SetErrorMessage("003");
                    }
                    AddErrors(result);
                }
            }
            else
                SetErrorMessage("003");
            SetHelpModal("Register");
            AjudasRegisto();
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }







        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            AjudasForgot();

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToAction(nameof(ForgotPasswordConfirmation));
                }

                // For more information on how to enable account confirmation and password reset please
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.ResetPasswordCallbackLink(user.Id, code, Request.Scheme);
                await _emailSender.SendEmailForgotPasswordAsync(model.Email, callbackUrl);
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }

            else
            {
                SetErrorMessage("003");
                AjudasForgot();

                // If we got this far, something failed, redisplay form
                return View(model);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null, string userId = null)
        {
            if (code == null || userId == null)
            {
                //throw new ApplicationException("A code must be supplied for password reset.");
            }
            AjudaReset();

            var model = new ResetPasswordViewModel { Code = code };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                SetErrorMessage("003");
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            else
                SetErrorMessage("005");
            AjudaReset();

            AddErrors(result);
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        #region Ajudas
        private void AjudasLogin()
        {
            ViewData["EmailLog"] = _ajudas.Single(ai => ai.Action == "Login" && ai.Elemento == "Email").Texto;
            ViewData["Password"] = _ajudas.Single(ai => ai.Action == "Login" && ai.Elemento == "Password").Texto;
            ViewData["RememberMe"] = _ajudas.Single(ai => ai.Action == "Login" && ai.Elemento == "RememberMe").Texto;
        }

        private void AjudasRegisto()
        {
            ViewData["Email"] = _ajudas.Single(ai => ai.Action == "Registo" && ai.Elemento == "Email").Texto;
            ViewData["Password"] = _ajudas.Single(ai => ai.Action == "Registo" && ai.Elemento == "Password").Texto;
            ViewData["ConfirmarPassword"] = _ajudas.Single(ai => ai.Action == "Registo" && ai.Elemento == "ConfirmarPassword").Texto;

        }

        private void AjudasForgot()
        {
            ViewData["Email"] = _ajudas.Single(ai => ai.Action == "ForgotPassword" && ai.Elemento == "Email").Texto;
        }

        private void AjudaReset()
        {
            ViewData["Password"] = _ajudas.Single(ai => ai.Action == "ResetPassword" && ai.Elemento == "Password").Texto;
            ViewData["ConfirmarPassword"] = _ajudas.Single(ai => ai.Action == "ResetPassword" && ai.Elemento == "ConfirmarPassword").Texto;
        }


        protected void SetErrorMessage(String Code)
        {
            var Erro = _erros.SingleOrDefault(e => e.Codigo == Code);
            TempData["Error_Code"] = Erro.Codigo;
            TempData["Error_Message"] = Erro.Mensagem;
        }

        protected void SetSuccessMessage(String Message)
        {
            TempData["Success"] = Message;
        }


        #endregion

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal_Re(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Waring_Email), "Home");
            }
        }


        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            //else if (User.Identity.Name == "akxeldacosta8@gmail.com")
            //{
            //    return RedirectToAction(nameof(HomeController.LayoutBackOffice), "Home");
            //} else if(User.Identity.Name == "costaalcemar@hotmail.com")
            //{
            //    return RedirectToAction(nameof(FuncionarioController.Layout_Func), "Funcionario");
            //}


            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }


        private void SetHelpModal(String Action)
        {
            ViewData["TextoModalAjuda"] = _ajudas.Single(ai => ai.Action == Action && ai.Elemento == "ModalAjuda").Texto;
        }
    }

    #endregion
}


