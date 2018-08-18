using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TicketingCRMNS.Api.DataAccess
{
	[Table("Admin", Schema="dbo")]
	public partial class Admin : AbstractEntity
	{
		public Admin()
		{
		}

		public virtual void SetProperties(
			string email,
			string firstName,
			int id,
			string lastName,
			string password,
			string phone,
			string username)
		{
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id;
			this.LastName = lastName;
			this.Password = password;
			this.Phone = phone;
			this.Username = username;
		}

		[MaxLength(128)]
		[Column("email")]
		public string Email { get; private set; }

		[MaxLength(128)]
		[Column("firstName")]
		public string FirstName { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(128)]
		[Column("lastName")]
		public string LastName { get; private set; }

		[MaxLength(128)]
		[Column("password")]
		public string Password { get; private set; }

		[MaxLength(128)]
		[Column("phone")]
		public string Phone { get; private set; }

		[MaxLength(128)]
		[Column("username")]
		public string Username { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c47ec2cae32d74ff8774d03e11e55fb5</Hash>
</Codenesium>*/