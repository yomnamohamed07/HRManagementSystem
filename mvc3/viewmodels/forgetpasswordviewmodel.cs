using System.ComponentModel.DataAnnotations;

namespace mvc3.viewmodels
{
	public class forgetpasswordviewmodel
	{
		[EmailAddress]
		public string email { get; set; }
	}
}
