using System.ComponentModel.DataAnnotations;

namespace mvc3.viewmodels
{
	public class resetpasswordviewmodel
	{
		[DataType(DataType.Password)]
		public string password { get; set; }
		[DataType(DataType.Password)]
		[Compare (nameof(password),ErrorMessage="passwordand confirmpassword not match")]
		public string confirmationpassword { get; set; }
		public string token { get; set; }
		public string email { get; set; }
	}
}
