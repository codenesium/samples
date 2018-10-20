using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerNS.Api.DataAccess
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
			string username,
			bool isDeleted)
		{
			this.Id = id;
			this.Password = password;
			this.Username = username;
			this.IsDeleted = isDeleted;
		}

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(128)]
		[Column("password")]
		public string Password { get; private set; }

		[MaxLength(128)]
		[Column("username")]
		public string Username { get; private set; }

		[Column("isDeleted")]
		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5945a602298b9f417e5cd73f6961124a</Hash>
</Codenesium>*/