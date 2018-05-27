using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Teacher", Schema="dbo")]
	public partial class Teacher: AbstractEntityFrameworkDTO
	{
		public Teacher()
		{}

		public void SetProperties(
			int id,
			DateTime birthday,
			string email,
			string firstName,
			string lastName,
			string phone,
			int studioId)
		{
			this.Birthday = birthday.ToDateTime();
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id.ToInt();
			this.LastName = lastName;
			this.Phone = phone;
			this.StudioId = studioId.ToInt();
		}

		[Column("birthday", TypeName="date")]
		public DateTime Birthday { get; set; }

		[Column("email", TypeName="varchar(128)")]
		public string Email { get; set; }

		[Column("firstName", TypeName="varchar(128)")]
		public string FirstName { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("lastName", TypeName="varchar(128)")]
		public string LastName { get; set; }

		[Column("phone", TypeName="varchar(128)")]
		public string Phone { get; set; }

		[Column("studioId", TypeName="int")]
		public int StudioId { get; set; }

		[ForeignKey("StudioId")]
		public virtual Studio Studio { get; set; }
	}
}

/*<Codenesium>
    <Hash>2827e76ffe92bf621479d1235bfa0292</Hash>
</Codenesium>*/