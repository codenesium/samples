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
			int id,
			DateTime birthday,
			string email,
			string firstName,
			string lastName,
			string phone,
			int userId)
		{
			this.Id = id;
			this.Birthday = birthday;
			this.Email = email;
			this.FirstName = firstName;
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
		public virtual User UserIdNavigation { get; private set; }

		public void SetUserIdNavigation(User item)
		{
			this.UserIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>ce71a443336cc0242d22aa9f54595ed4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/