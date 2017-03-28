using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIbrary.Data.Entities;

namespace LIbrary.Data.Abstract
{
   
    /// <summary>
    /// Интерфейс хранилища книг
    /// </summary>
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
        void SaveBook ( Book book ); 
        Book DeleteBook ( int BookId );
       
    }
}
