using STOChernysh.Models;
using STOChernysh.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STOChernysh.Pages
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkoutForm.Visible = true;
            checkoutMessage.Visible = false;
            Repository repository = new Repository();
            if (IsPostBack)
            {
                Order order = new Order();
                
                if (TryUpdateModel(order, new FormValueProvider(ModelBindingExecutionContext)))
                {
                    order.OrderLines = new List<OrderLine>();
                    order.Masters_MasterId = repository.Master[new Random().Next(0, repository.Master.Count)].MasterId;
                    Crt cart = SessionHelper.GetCart(Session);

                    foreach (CrtLine line in cart.Lines)
                    {
                        order.OrderLines.Add(new OrderLine()
                        {
                            Order = order,
                            Service = line.Service,
                            Quantity = line.Quantity
                        });
                    }

                    new Repository().SaveOrder(order);

                    // отправитель - устанавливаем адрес и отображаемое в письме имя
                    MailAddress from = new MailAddress("kormet61@gmail.com", "STOShop");
                    // кому отправляем
                    MailAddress to = new MailAddress(mail.Value);
                    // создаем объект сообщения
                    MailMessage m = new MailMessage(from, to);
                    // тема письма
                    m.Subject = "Тест";
                    // текст письма
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in SessionHelper.GetCart(Session).Lines)
                    {
                        sb.Append("<tr><td>"+item.Service.Name+"</td>"+ "<td>" + item.Quantity + "</td>"+"<td>"+(item.Service.Price*item.Quantity).ToString("c")+"</td>" +"</tr>");
                            
                    }
                    m.Body = "<h2>Спасибо за покупку!</h2> " +
                        "<table>"+sb.ToString()+"</table>";

                    // письмо представляет код html
                    m.IsBodyHtml = true;
                    // адрес smtp-сервера и порт, с которого будем отправлять письмо
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    // логин и пароль
                    smtp.Credentials = new NetworkCredential("kormet61@gmail.com", "Rjhybqxer1");
                    smtp.EnableSsl = true;
                    smtp.Send(m);

                    cart.Clear();

                    checkoutForm.Visible = false;
                    checkoutMessage.Visible = true;
                }
            }
        }
    }
}