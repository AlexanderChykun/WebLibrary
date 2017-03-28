using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Library.WebUI.Infrastructure.Abstract;

namespace Library.WebUI.Infrastructure.Concrete
{
    /// <summary>
    /// класс реализующий интерфейс IAuthProvider
    /// </summary>
    public class FormsAuthProvider:IAuthProvider
    {
        /// <summary>
        /// Метод авторизации
        /// </summary>
        /// <param name="username">имя пользователя</param>
        /// <param name="password">пароль</param>
        /// <returns></returns>
        public bool Authenticate ( string username, string password )
        {
            bool result = FormsAuthentication.Authenticate( username, password ); //Аутентификация
            if ( result )
            {
                FormsAuthentication.SetAuthCookie ( username, false ); //передача Cookie
            }
            return result;
        }

    }
}