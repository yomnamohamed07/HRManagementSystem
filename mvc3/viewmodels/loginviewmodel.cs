using System.ComponentModel.DataAnnotations;

namespace mvc3.viewmodels
{
	public class loginviewmodel
	{
		[Required]
		[EmailAddress(ErrorMessage ="invalid email")]
		public string email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string password { get; set; }
		public bool rememberme { get; set; }
	}
}
