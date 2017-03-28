using LIbrary.Data.Abstract;
using LIbrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbrary.Data.Concrete
{
    /// <summary>
    /// Класс реализующий интерфейс IUserRepository
    /// </summary>
    public class EFUserRepository:IUserRepository
    {
        private EFDbContext context = new EFDbContext ();
        public IQueryable<User> Users
        {
            get
            {
                return context.Users;
            }
        }
        /// <summary>
        /// Метод добавления пользователя в базу данных
        /// </summary>
        /// <param name="user">пользователь</param>
        public void AddUser ( User user )
        {
            bool IsSame = false;
            if ( context.Users.LongCount() == 0 )
            {
                context.Users.Add ( new User
                    {
                        Name = user.Name,
                        Mail = user.Mail
                    } );
                context.SaveChanges ();
            }
            else
            {
                foreach ( var item in Users )
                {
                    if ( item.Mail == user.Mail )
                    {
                        IsSame = true;
                    }
                }
                if (!IsSame)
	            {
		            context.Users.Add ( new User
                        {
                            Name = user.Name,
                            Mail = user.Mail
                        } );
                    context.SaveChanges ();
	            }     
            }
        }
    }
}
