using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerNS.Api.DataAccess
{
	[Table("Admin", Schema="dbo")]
	public partial class Admin : AbstractEntity
	{
		public Admin()
		{
		}

		public virtual void SetProperties(
			DateTime? birthday,
			string email,
			string firstName,
			int id,
			string lastName,
			string phone,
			int userId,
			bool isDeleted)
		{
			this.Birthday = birthday;
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id;
			this.LastName = lastName;
			this.Phone = phone;
			this.UserId = userId;
			this.IsDeleted = isDeleted;
		}

		[Column("birthday")]
		public DateTime? Birthday { get; private set; }

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
		[Column("phone")]
		public string Phone { get; private set; }

		[Column("userId")]
		public int UserId { get; private set; }

		[Column("isDeleted")]
		public bool IsDeleted { get; private set; }

		[ForeignKey("UserId")]
		public virtual User UserNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>191d4a02d09492d07c80ed8996d1ba0e</Hash>
</Codenesium>*/