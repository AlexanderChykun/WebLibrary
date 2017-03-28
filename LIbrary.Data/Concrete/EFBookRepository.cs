using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIbrary.Data.Entities;
using LIbrary.Data.Abstract;
using System.Data.Entity;

namespace LIbrary.Data.Concrete
{
    /// <summary>
    /// класс реализующий интерфейс IBookRepository
    /// </summary>
    public class EFBookRepository:IBookRepository
    {
        private EFDbContext context = new EFDbContext ();
        public IQueryable<Book> Books
        {
            get
            {
                return context.Books;
            }
        }
        /// <summary>
        /// Метод сохранения книги
        /// </summary>
        /// <param name="book">книга</param>
        public void SaveBook ( Book book )
        {
            if ( book.BookID == 0 )
            {
                context.Books.Add ( book );
            }
            else
            {
                Book dbEntry = context.Books.Find ( book.BookID );
                if ( dbEntry!=null )
                {
                    dbEntry.Title = book.Title;
                    dbEntry.Description = book.Description;
                    dbEntry.Author = book.Author;
                }
            }
            context.SaveChanges ();
        }
        /// <summary>
        /// Уделение книги
        /// </summary>
        /// <param name="bookId">идентификационный номер книги</param>
        /// <returns></returns>
        public Book DeleteBook ( int bookId )
        {
            Book dbEntry = context.Books.Find ( bookId );
            if ( dbEntry!=null )
            {
                context.Books.Remove ( dbEntry );
                context.SaveChanges ();
            }
            return dbEntry;
        }
        
    }
}
