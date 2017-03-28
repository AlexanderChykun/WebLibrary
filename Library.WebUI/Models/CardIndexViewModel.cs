using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LIbrary.Data.Entities;

namespace Library.WebUI.Models
{
    /// <summary>
    /// Модель представления карты пользователя
    /// </summary>
    public class CardIndexViewModel
    {
        public Card Card { get; set; }
        public string ReturnUrl { get; set; }
    }
}