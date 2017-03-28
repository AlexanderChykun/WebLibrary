using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIbrary.Data.Abstract;

namespace Library.WebUI.Controllers
{
    /// <summary>
    /// Контроллер выборки книг по авторам
    /// </summary>
    public class NavController : Controller
    {
        private IBookRepository _repository;

        public NavController (IBookRepository repozit)
        {
            _repository = repozit;
        }
        /// <summary>
        /// Метод частичного представления списка авторов
        /// </summary>
        /// <param name="author">имя автора</param>
        /// <returns></returns>
        public PartialViewResult Menu (string author = null)
        {
            ViewBag.SelectedAuthor = author;
            IEnumerable<string> authors = _repository.Books
                .Select ( x => x.Author )
                .Distinct ()
                .OrderBy ( x => x );
            return PartialView(authors);
        }
    }
}
