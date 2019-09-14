using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CADNS.Api.DataAccess
{
	[Table("Officer", Schema="dbo")]
	public partial class Officer : AbstractEntity
	{
		public Officer()
		{
		}

		public virtual void SetProperties(
			int id,
			string badge,
			string email,
			string firstName,
			string lastName,
			string password)
		{
			this.Id = id;
			this.Badge = badge;
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Password = password;
		}

		[MaxLength(128)]
		[Column("badge")]
		public virtual string Badge { get; private set; }

		[MaxLength(128)]
		[Column("email")]
		public virtual string Email { get; private set; }

		[MaxLength(128)]
		[Column("firstName")]
		public virtual string FirstName { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("lastName")]
		public virtual string LastName { get; private set; }

		[MaxLength(128)]
		[Column("password")]
		public virtual string Password { get; private set; }
	}
}

/*<Codenesium>
    <Hash>497c902a15276134a98388c11de3c901</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/