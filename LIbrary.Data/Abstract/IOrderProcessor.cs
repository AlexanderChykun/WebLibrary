using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIbrary.Data.Entities;

namespace LIbrary.Data.Abstract
{
    /// <summary>
    /// Интерфейс для авторизации
    /// </summary>
    public interface IOrderProcessor
    {
        void ProcessOrder ( Card card, User user );
    }
}
