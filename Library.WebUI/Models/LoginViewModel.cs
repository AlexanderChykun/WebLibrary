using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Library.WebUI.Models
{
    /// <summary>
    /// Модель представления авторизации
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Имя администратора
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [DataType ( DataType.Password )]
        public string Password { get; set; }
    }
}