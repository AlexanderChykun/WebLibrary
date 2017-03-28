using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LIbrary.Data.Entities
{
    /// <summary>
    /// Класс книга
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Идентификационный номер книги
        /// </summary>
        [HiddenInput(DisplayValue = false)]  //скрытый элемент формы 
        public int BookID { get; set; }
        /// <summary>
        /// Название книги
        /// </summary>
        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }
        /// <summary>
        /// Описание книги
        /// </summary>
        [Required ( ErrorMessage = "Please enter a description" )]
        [DataType(DataType.MultilineText)]  //многострочный текст
        public string Description { get; set; }
        /// <summary>
        /// Автор книги
        /// </summary>
       [Required ( ErrorMessage = "Please enter an author" )]
        public string Author { get; set; }
    }
}
