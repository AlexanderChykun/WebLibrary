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
    /// Контроллер карты пользователя 
    /// </summary>
    public class CardController : Controller
    {
        private IBookRepository _repository;
        private IOrderProcessor _orderProcessor;
        private IHistoryRepository _historyRep;
        private IUserRepository _userRep;
        /// <summary>
        /// Конструктор карты пользователя
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="proc"></param>
        /// <param name="hrepos"></param>
        /// <param name="urep"></param>
        public CardController (IBookRepository repo, IOrderProcessor proc,
            IHistoryRepository hrepos,IUserRepository urep)
        {
            _repository = repo;
            _orderProcessor = proc;
            _historyRep = hrepos;
            _userRep = urep;
        }
        /// <summary>
        /// метод отображения карты пользователя
        /// </summary>
        /// <param name="card">карта пользователя</param>
        /// <param name="returnUrl">ссылка</param>
        /// <returns></returns>
        public ViewResult Index ( Card card, string returnUrl )
        {
            return View ( new CardIndexViewModel
            {
                Card = card,
                ReturnUrl = returnUrl
            } );
        }
        /// <summary>
        /// Добавление в карту пользователя
        /// </summary>
        /// <param name="card">карта пользователя</param>
        /// <param name="bookId">идентификатор книги</param>
        /// <param name="returnUrl">ссылка для перенаправления</param>
        /// <returns></returns>
        public RedirectToRouteResult AddToCard ( Card card, int bookId, string returnUrl )
        {
            Book book = _repository.Books
                .FirstOrDefault ( b => b.BookID == bookId );
            if ( book != null )
            {
                card.AddItem ( book, 1 );
            }
            return RedirectToAction ( "Index", new { returnUrl } ); ;
        }
        /// <summary>
        /// Удаление с карты пользователя
        /// </summary>
        /// <param name="card">Карта пользователя</param>
        /// <param name="bookId">Идентификатор книги</param>
        /// <param name="returnUrl">ссылка для перенаправления</param>
        /// <returns></returns>
        public RedirectToRouteResult RemoveFromCard ( Card card, int bookId, string returnUrl )
        {
            Book book = _repository.Books
                .FirstOrDefault ( b => b.BookID == bookId );
            if ( book != null )
            {
                card.RemoveLine ( book );
            }
            return RedirectToAction ( "Index", new { returnUrl } );
        }
        /// <summary>
        /// Методчастичного отображения суммарного количества книг
        /// </summary>
        /// <param name="card">карта пользователя</param>
        /// <returns></returns>
        public PartialViewResult Summary ( Card card )
        {
            return PartialView ( card );
        }
        /// <summary>
        /// Метод отображения полей ввода пользователя
        /// </summary>
        /// <returns></returns>
        public ViewResult Checkout ()
        {
            return View ( new User () );
        }
        /// <summary>
        /// POST:метод отображения после подтверждения выборки книг 
        /// </summary>
        /// <param name="card">карта пользователя</param>
        /// <param name="user">пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult Checkout(Card card, User user)
        {
            if (card.Lines.Count() == 0)
	        {
		        ModelState.AddModelError("","Sorry, your card is empty!" );
	        }
            if (ModelState.IsValid)
	        {
		        _orderProcessor.ProcessOrder(card, user);
                foreach ( var item in card.Lines )
                {
                    _historyRep.AddTakenBook ( item.Book, user );//добавить в историю
                }
                _userRep.AddUser ( user );
                card.Clear();
                return View("Completed");
	        }
            else
            {
                return View(user);
            }
        }
      
             
    }
}
