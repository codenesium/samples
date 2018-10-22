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
			string username)
		{
			this.Id = id;
			this.Password = password;
			this.Username = username;
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
	}
}

/*<Codenesium>
    <Hash>daf364fda2e84a79ff27df04cac73219</Hash>
</Codenesium>*/