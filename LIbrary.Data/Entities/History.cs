using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LIbrary.Data.Entities
{
    /// <summary>
    /// Класс история взятых книг
    /// </summary>
    public class History
    {
        /// <summary>
        /// идентификационный номер записи
        /// </summary>
        [HiddenInput ( DisplayValue = false )]  
        public int HistoryId { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Дата взятия книги
        /// </summary>
        public System.DateTime Date { get; set; }
        /// <summary>
        /// Название книги
        /// </summary>
        public string BookTitle { get; set; }
    }
}
