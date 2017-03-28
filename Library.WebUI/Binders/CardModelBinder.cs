using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LIbrary.Data.Entities;

namespace Library.WebUI.Binders
{
    /// <summary>
    /// Класс для связывания данных
    /// </summary>
    public class CardModelBinder: IModelBinder
    {
        private const string sessionKey = "Card";
        public object BindModel ( ControllerContext controllerContext, ModelBindingContext bindingContext )
        {
            //получение карты из сессии
            Card card = (Card) controllerContext.HttpContext.Session[sessionKey]; //получаем данные сессии
            //создание карты если ее не было
            if ( card == null )
            {
                card = new Card ();
                controllerContext.HttpContext.Session[sessionKey] = card;// устанавливаем даннные сессии
            }
            return card;
        }
    }
}