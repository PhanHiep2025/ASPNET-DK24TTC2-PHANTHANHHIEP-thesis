using ShoesStore.InterfaceRepositories;
using System.Net;
using System.Net.Mail;

namespace ShoesStore.Repositories
{
	public class EmailSender : IEmailSender
	{
		public void SendEmail(string email,string subject, string message)
		{
			var mail = "phanhiepcc2026@gmail.com";
			var pw = "Phan@2026";

			var client = new SmtpClient("smtp.gmail.com", 587)
			{
				EnableSsl = true,
				Credentials =  new NetworkCredential(mail, pw),
			};

			client.SendMailAsync(new MailMessage(
				from: mail,
				to: email,
				subject,
				message));
		}
	}
}
