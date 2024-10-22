using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace mvc3.viewmodels
{
	public class registerviewmodel
	{
		[Required(ErrorMessage ="first name is requird")]
		public string firstname { get; set; }
		[Required(ErrorMessage = "last name is requird")]
		public string lastname { get; set; }
		[Required(ErrorMessage = "user name is requird")]
		public string  username{ get; set; }
		[EmailAddress(ErrorMessage = "is unvalid email")]
		public string email { get; set; }
		[DataType(DataType.Password)]
		public string password { get; set; }
		[DataType(DataType.Password)]
		[Compare(nameof(password),ErrorMessage ="password or confirmpassword not match")]
		public string confirmationpassword { get; set; }
		public bool isagree { get; set; }
	}
}
