using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	[Table("User", Schema="dbo")]
	public partial class User : AbstractEntity
	{
		public User()
		{
		}

		public virtual void SetProperties(
			int id,
			string password,
			string username)
		{
			this.Id = id;
			this.Password = password;
			this.Username = username;
		}

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("password")]
		public virtual string Password { get; private set; }

		[MaxLength(128)]
		[Column("username")]
		public virtual string Username { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0f2ff9e2b6e3207389d2abc28c7c183b</Hash>
</Codenesium>*/