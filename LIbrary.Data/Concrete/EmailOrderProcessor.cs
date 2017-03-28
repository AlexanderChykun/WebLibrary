using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using LIbrary.Data.Abstract;
using LIbrary.Data.Entities;
using System.Net;

namespace LIbrary.Data.Concrete
{
    /// <summary>
    /// Класс установок для отправки электронной почты
    /// </summary>
    public class EmailSettings
    {
        public string MailToAddress = "orders@example.com";
        public string MailFromAddress = "library@example.com";
        public bool UseSsl = true;
        public string Username = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = false;
        public string FileLocation = @"c:\library_emails";
    }
    /// <summary>
    /// Класс реализующи интерфейс IOrderProcessor для отправки заказа по эл. почте
    /// </summary>
    public class EmailOrderProcessor : IOrderProcessor
    {
        /// <summary>
        /// Поле установок
        /// </summary>
        private EmailSettings emailSettings;
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="settings">установки</param>
        public EmailOrderProcessor ( EmailSettings settings )
        {
            emailSettings = settings;
        }
        /// <summary>
        /// Метод отправки заказа по эл. почте
        /// </summary>
        /// <param name="card">карточка заказчика</param>
        /// <param name="user">пользователь</param>
        public void ProcessOrder ( Card card, User user )
        {
            using ( var smtpClient = new SmtpClient () )
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential ( emailSettings.Username,
                emailSettings.Password );
                if ( emailSettings.WriteAsFile )
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }
                StringBuilder body = new StringBuilder ()
                .AppendLine ( "A new order has been submitted" )
                .AppendLine ( "---" )
                .AppendLine ( "Items:" );
                foreach ( var line in card.Lines )
                {
                    var subtotal = line.Quantity;
                    body.AppendFormat ( "{0} x {1} (subtotal: {2}", line.Quantity,
                    line.Book.Title, subtotal );
                }
                body.AppendFormat ( "Total order: {0}", card.ComputeTotalStore () )
                .AppendLine ( "---" )
                .AppendLine ( "Send to:" )
                .AppendLine ( user.Name );

                MailMessage mailMessage = new MailMessage (
                emailSettings.MailFromAddress,  // From
                emailSettings.MailToAddress,    // To
                "New order submitted!",         // Subject
                body.ToString () );             // Body
                if ( emailSettings.WriteAsFile )
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }
                //smtpClient.Send ( mailMessage );
            }
        }
    }
}
