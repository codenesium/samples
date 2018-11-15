using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	[Table("Teacher", Schema="dbo")]
	public partial class Teacher : AbstractEntity
	{
		public Teacher()
		{
		}

		public virtual void SetProperties(
			DateTime birthday,
			string email,
			string firstName,
			int id,
			string lastName,
			string phone,
			int userId)
		{
			this.Birthday = birthday;
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id;
			this.LastName = lastName;
			this.Phone = phone;
			this.UserId = userId;
		}

		[Column("birthday")]
		public virtual DateTime Birthday { get; private set; }

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
		[Column("phone")]
		public virtual string Phone { get; private set; }

		[Column("userId")]
		public virtual int UserId { get; private set; }

		[ForeignKey("UserId")]
		public virtual User UserNavigation { get; private set; }

		public void SetUserNavigation(User item)
		{
			this.UserNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>2ba7c9982cb9ab2e14aa9fdb3c1c4b75</Hash>
</Codenesium>*/