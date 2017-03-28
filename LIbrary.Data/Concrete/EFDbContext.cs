using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIbrary.Data.Entities;
using System.Data.Entity;

namespace LIbrary.Data.Concrete
{
    //класс для связывания модели с базой данных
     public class EFDbContext:DbContext
    {
         public DbSet<Book> Books { get; set; } //с базой данных книг
         public DbSet<User> Users { get; set; } //с базой данных пользователей
         public DbSet<History> Histories { get; set; }  //с базой данных истории использования библиотеки
    }
}
