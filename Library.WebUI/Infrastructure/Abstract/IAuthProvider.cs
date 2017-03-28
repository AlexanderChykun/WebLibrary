using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebUI.Infrastructure.Abstract
{
    /// <summary>
    /// Интерфейс авторизации
    /// </summary>
    public interface IAuthProvider
    {
        bool Authenticate ( string name, string password );
    }
}
