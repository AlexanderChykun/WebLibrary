using LIbrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbrary.Data.Abstract
{
    /// <summary>
    /// Интерфейс для хранилища пользователей
    /// </summary>
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void AddUser ( User user );
    }
}
