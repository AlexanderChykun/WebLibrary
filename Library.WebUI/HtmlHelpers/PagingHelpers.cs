using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.WebUI.Models;
using System.Web.Mvc;
using System.Text;

namespace Library.WebUI.HtmlHelpers
{
    /// <summary>
    /// Статический класс помощник в HTML
    /// </summary>
    public static class PagingHelpers
    {
        /// <summary>
        /// Метод генерирует HTML для набора ссылок на страницы
        /// </summary>
        /// <param name="html">экземпляр данного класа</param>
        /// <param name="pagingInfo">информация с страницы</param>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        public static MvcHtmlString PageLinks(
            this HtmlHelper html,
            PagingInfo pagingInfo,
            Func<int, string> pageUrl )
        {
            StringBuilder result = new StringBuilder ();
            for ( int i = 1; i <= pagingInfo.TotalPages; i++ )//генерация html для набора ссылок, исп. информацию  в объекте Paginginfo
            {
                TagBuilder tag = new TagBuilder ( "a" );
                tag.MergeAttribute ( "href", pageUrl ( i ) );
                tag.InnerHtml = i.ToString ();
                if ( i == pagingInfo.CurrentPage )
                {
                    tag.AddCssClass ( "selected" );
                }
                result.Append ( tag.ToString () );
            }
            return MvcHtmlString.Create ( result.ToString () );
        }
    }
}