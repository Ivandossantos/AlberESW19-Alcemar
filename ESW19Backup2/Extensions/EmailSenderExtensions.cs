using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ESW19Backup2.Models;
using ESW19Backup2.Services;

namespace ESW19Backup2.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }

        public static Task SendEmailForgotPasswordAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Recuperação de Password",
                $"Recebemos o seu pedido de recuperação de password. <br /> " +
                $"Pode proceder através do seguinte link: <a href='{HtmlEncoder.Default.Encode(link)}'>RECUPERAR PASSWORD</a>" +
                $"<br /><br />Caso não tenha feito nenhum pedido de recuperação de password, ignore este e-mail");

        }

       
    }
}
