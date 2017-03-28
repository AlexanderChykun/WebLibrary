using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbrary.Data.Entities
{
    /// <summary>
    /// Класс карточки пользователя библиотеки
    /// </summary>
    public class Card 
    {
        /// <summary>
        /// список выбраных книг
        /// </summary>
        private List<CartLine> lineCollection = new List<CartLine>();
        /// <summary>
        /// Добавить запись
        /// </summary>
        /// <param name="book">книга</param>
        /// <param name="quantity">количество</param>
        public void AddItem ( Book book, int quantity )
        {
            CartLine line = lineCollection
                .Where(b=>b.Book.BookID == book.BookID)
                .FirstOrDefault();
            if (line == null)
	        {
		        lineCollection.Add(new CartLine{
                    Book = book,
                    Quantity = quantity
                });
	        }
            else
            {
                line.Quantity += quantity;
            }
        }
        /// <summary>
        /// Удалить строку
        /// </summary>
        /// <param name="book">книга</param>
        public void RemoveLine (Book book)
        {
            lineCollection.RemoveAll(l => l.Book.BookID == book.BookID);
        }
        /// <summary>
        /// Подсчет суммарного количества книг
        /// </summary>
        /// <returns></returns>
        public int ComputeTotalStore()
        {
            return lineCollection.Sum(e => e.Quantity);
        }
        /// <summary>
        /// Очистка карточки
        /// </summary>
        public void Clear()
        {
            lineCollection.Clear();
        }
        /// <summary>
        /// Доступ к содержимому карты
        /// </summary>
        public IEnumerable<CartLine> Lines
        {
            get
            {
                return lineCollection;
            }
        }
    }
    
    
    /// <summary>
    /// Класс строка карты,представляющий выбраную книгу и количество книг
    /// </summary>
    public class CartLine
    {
        public Book Book{get;set;}
        public int Quantity {get;set;}
    }
}
