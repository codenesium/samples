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
    <Hash>94cadf7be6b242a659d18b56c570b5e1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/