using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.WebUI.Infrastructure.Abstract;
using Library.WebUI.Models;

namespace Library.WebUI.Controllers
{
    /// <summary>
    /// Контроллер авторизации
    /// </summary>
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        public AccountController ( IAuthProvider auth )
        {
            authProvider = auth;
        }
        /// <summary>
        /// GET: Метод авторизации
        /// </summary>
        /// <returns></returns>
        public ViewResult Login ()
        {
            return View ();
        }
        /// <summary>
        /// POST: Метод авторизации
        /// </summary>
        /// <param name="model">модель авторизации</param>
        /// <param name="returnUrl">адрес перехода</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login ( LoginViewModel model, string returnUrl )
        {
            if ( ModelState.IsValid )
            {
                if (authProvider.Authenticate ( model.UserName, model.Password ) )
                {
                    return Redirect ( returnUrl ?? Url.Action ( "Index", "Admin" ) );
                }
                else
                {
                    ModelState.AddModelError ( "", "Incorrect username or password" );
                    return View ();
                }
            }
            else
            {
                return View ();
            }
        }
    }
}



