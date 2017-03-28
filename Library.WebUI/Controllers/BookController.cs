using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIbrary.Data.Abstract;
using LIbrary.Data.Entities;
using Library.WebUI.Models;

namespace Library.WebUI.Controllers
{
    /// <summary>
    /// Контроллер книг
    /// </summary>
    public class BookController : Controller
    {
        private IBookRepository _repository;
        public int PageSize = 3;// хотим видеть 3 книги на странице
        /// <summary>
        /// конструктор контроллера
        /// </summary>
        /// <param name="bookRepository"></param>
        public BookController ( IBookRepository bookRepository )
        {
            this._repository = bookRepository;
        }
        /// <summary>
        /// метод для визуализации списка книг постранично
        /// </summary>
        /// <param name="author">имя автора</param>
        /// <param name="page">номер страницы</param>
        /// <returns></returns>
        public ViewResult List (string author, int page = 1)
        {
            BooksListViewModel model = new BooksListViewModel
        {
            Books = _repository.Books
                .Where(b => author == null || b.Author == author)//если не содержит null будут выбраны объекты с свойством Author
                .OrderBy(b => b.BookID)
                .Skip ((page - 1)*PageSize)
                .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                BooksPerPage = PageSize,
                TotalBooks = author ==null ?
                _repository.Books.Count() :
                _repository.Books.Where(e => e.Author ==author).Count()
            },
            CurrentAuthor = author
        };
            return View ( model );
        }
    }
}
