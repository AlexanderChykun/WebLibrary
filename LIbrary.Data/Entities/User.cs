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
    /// Класс описывающий пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификационный номер пользователя
        /// </summary>
        [HiddenInput ( DisplayValue = false )]  //скрытый элемент формы 
        public int UserID { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        /// <summary>
        /// E-mail пользователя
        /// </summary>
        [Required(ErrorMessage = "Please enter a mail" )]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Mail { get; set; }
    }
}
