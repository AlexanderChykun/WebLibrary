using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LIbrary.Data.Entities;

namespace Library.WebUI.Models
{
    /// <summary>
    /// Модель представления списка книг
    /// </summary>
    public class BooksListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentAuthor { get; set; }
    }
}