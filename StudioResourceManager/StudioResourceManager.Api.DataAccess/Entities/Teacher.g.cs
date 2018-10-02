using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerNS.Api.DataAccess
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
		public DateTime Birthday { get; private set; }

		[MaxLength(128)]
		[Column("email")]
		public string Email { get; private set; }

		[MaxLength(128)]
		[Column("firstName")]
		public string FirstName { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

		[ForeignKey("UserId")]
		public virtual User UserNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4e13171d443b5f64e16aec3bb9b678e1</Hash>
</Codenesium>*/