using System;
using System.Web.Routing;
using Ninject;
using System.Web.Mvc;
using LIbrary.Data.Entities;
using LIbrary.Data.Abstract;
using System.Collections.Generic;
using System.Linq;
using Moq;
using LIbrary.Data.Concrete;
using System.Configuration;
using Library.WebUI.Infrastructure.Abstract;
using Library.WebUI.Infrastructure.Concrete;

namespace Library.WebUI.Infrastructure
{
    /// <summary>
    /// Реализация фабрики контроллеров
    /// </summary>
    public class NinjectControllerFactory: DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        /// <summary>
        /// контруктор
        /// </summary>
        public NinjectControllerFactory ()
        {
            ninjectKernel = new StandardKernel ();
            AddBindings ();
        }
        /// <summary>
        /// Получение объекта контроллера
        /// </summary>
        /// <param name="requestContext">запрашиваемый контроллер</param>
        /// <param name="controllerType">тип контроллера</param>
        /// <returns></returns>
        protected override IController GetControllerInstance ( RequestContext requestContext, Type controllerType )
        {
            //получение объекта контроллера из контейнера по его типу
            return controllerType == null ? null : (IController) ninjectKernel.Get ( controllerType );
        }
        /// <summary>
        /// конфигурация контейнера
        /// </summary>
        private void AddBindings ()
        {
            ninjectKernel.Bind<IBookRepository> ().To<EFBookRepository> ();
            //хотим создавать экземпляры класса EFBookRepository для обслуживания запросов к IBookRepository
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse ( ConfigurationManager
                .AppSettings["Email.WriteAsFile"] ?? "false" )
            };
            ninjectKernel.Bind<IOrderProcessor> ()
                .To<EmailOrderProcessor> ()
                .WithConstructorArgument ( "settings", emailSettings );
            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider> ();
            ninjectKernel.Bind<IHistoryRepository> ().To<EFHistoryRepository> ();
            ninjectKernel.Bind<IUserRepository> ().To<EFUserRepository> ();
        }
    }
}