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
    /// Класс реализующий интерфейс IHistoryRepository
    /// </summary>
    public class EFHistoryRepository: IHistoryRepository
    {
        private EFDbContext context = new EFDbContext ();
        public IQueryable<History> Histories
        {
            get
            {
                return context.Histories;
            }
        }
        /// <summary>
        /// Добавить взятую книгу в историю
        /// </summary>
        /// <param name="book">книга</param>
        /// <param name="user">пользователь</param>
        public void AddTakenBook (Book book, User user)
        {
            context.Histories.Add ( new History { 
                UserName = user.Name,
                BookTitle = book.Title,
                Date = DateTime.Now
                });
            context.SaveChanges ();
        }
    }
}
