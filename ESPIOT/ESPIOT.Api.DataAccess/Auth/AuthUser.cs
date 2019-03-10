using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESPIOTNS.Api.DataAccess.Auth
{
	[Table("AuthUser")]
	public partial class AuthUser : AbstractEntity
	{
		public AuthUser()
		{
		}

		public virtual void SetProperties(
			int id,
			string email,
			string password)
		{
			this.Id = id;
			this.Email = email;
			this.Password = password;
		}

		[MaxLength(90)]
		[Column("email")]
		public virtual string Email { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(90)]
		[Column("password")]
		public virtual string Password { get; private set; }
	}
}
