using System.Net;
using System.Net.Mail;
namespace mvc3.utilities
{
	public class mail
	{
		public string subject { get; set; }
		public string body { get; set; }
		public string recipient { get; set; }
	}
	public class mailsetting
	{
		public  static void sendemail(mail email)
		{
			var client = new SmtpClient("smtp.gmail.com", 587);
			
			client.EnableSsl = true;
			client.Credentials = new NetworkCredential("yomnamohamed30000@gmail.com", "tttybcdwlswbcshe");
			client.Send("yomnamohamed30000@gmail.com", email.recipient, email.subject, email.body);
		
		
		
		}
	}
}
