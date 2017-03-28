using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIbrary.Data.Abstract;
using LIbrary.Data.Entities;

namespace Library.WebUI.Controllers
{
    /// <summary>
    /// Контроллер администратора
    /// </summary>
    [Authorize] //стандартный фильтр авторизации
    public class AdminController : Controller
    {
        private IBookRepository _repository;
        private IHistoryRepository _historyRepo;
        private IUserRepository _userRep;
        /// <summary>
        /// Конструктор контроллера администратора
        /// </summary>
        /// <param name="repo"></param>
        public AdminController ( IBookRepository repo, IHistoryRepository hrepo,
            IUserRepository urep)
        {
            _repository = repo;
            _historyRepo = hrepo;
            _userRep = urep;
        }
        /// <summary>
        /// Метод Index
        /// </summary>
        /// <returns></returns>
        public ViewResult Index ()
        {
            return View ( _repository.Books );
        }
        /// <summary>
        /// GET: Метод находящий книгу по ID и передающий его в качестве объекта представления
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public ViewResult Edit ( int bookId )
        {
            Book book = _repository.Books
                .FirstOrDefault ( b => b.BookID == bookId );
            return View ( book ); 
        }
        /// <summary>
        /// POST: метод редактирования книги
        /// </summary>
        /// <param name="book">редактируемая книга</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit ( Book book )
        {
            if ( ModelState.IsValid )
            {
                _repository.SaveBook ( book );
                TempData["message"] = string.Format ( "{0} has been saved", book.Title );
                return RedirectToAction ( "Index" );
            }
            else
            {   //Срабатыевает когда чтото не правильно введено
                return View ( book );
            }
        }
        /// <summary>
        /// Создание книги
        /// </summary>
        /// <returns></returns>
        public ViewResult Create ()
        {
            return View ( "Edit", new Book () );
        }
        /// <summary>
        /// POST:удаление книги
        /// </summary>
        /// <param name="bookId">идентификатор книги</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete ( int bookId )
        {
            Book deletedBook = _repository.DeleteBook ( bookId );
            if ( deletedBook!=null )
            {
                TempData["message"] = string.Format ( "{0} was deleted", deletedBook.Title );

            }
            return RedirectToAction ( "Index" );
        }
        /// <summary>
        /// Метод отображения истории взятия книг из библиотеки
        /// </summary>
        /// <returns></returns>
        public ViewResult History ()
        {
            return View ( _historyRepo.Histories );
        }
        /// <summary>
        /// Метод отображения пользователей библиотеки
        /// </summary>
        /// <returns></returns>
        public ViewResult GetUsers ()
        {
            return View ( _userRep.Users );
        }
       
    }
}
