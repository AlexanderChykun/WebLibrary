using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.WebUI.Models
{
    /// <summary>
    /// Модель представления информации о книгах в библиотеке
    /// </summary>
    public class PagingInfo
    {
        public int TotalBooks { get; set;}      //всего книг
        public int BooksPerPage { get; set; }   //книг на странице
        public int CurrentPage { get; set; }    //текущая страница

        public int TotalPages                   //общее количество страниц
        {
            get
            {
                return (int) Math.Ceiling ( (decimal) TotalBooks / BooksPerPage );
            }
        }
    }
}