using LIbrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIbrary.Data.Abstract
{
    /// <summary>
    /// Интерфейс для хранилища истории взятия книг
    /// </summary>
     public interface IHistoryRepository
    {
        IQueryable<History> Histories { get; }
        void AddTakenBook ( Book book, User user );
    }
}
