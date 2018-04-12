using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.Contracts
{
	[Table("Teacher", Schema="dbo")]
	public partial class EFTeacher
	{
		public EFTeacher()
		{}

		public void SetProperties(
			int id,
			string firstName,
			string lastName,
			string email,
			string phone,
			DateTime birthday,
			int studioId)
		{
			this.Id = id.ToInt();
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Email = email;
			this.Phone = phone;
			this.Birthday = birthday;
			this.StudioId = studioId.ToInt();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("firstName", TypeName="varchar(128)")]
		public string FirstName { get; set; }

		[Column("lastName", TypeName="varchar(128)")]
		public string LastName { get; set; }

		[Column("email", TypeName="varchar(128)")]
		public string Email { get; set; }

		[Column("phone", TypeName="varchar(128)")]
		public string Phone { get; set; }

		[Column("birthday", TypeName="date")]
		public DateTime Birthday { get; set; }

		[Column("studioId", TypeName="int")]
		public int StudioId { get; set; }

		[ForeignKey("StudioId")]
		public virtual EFStudio Studio { get; set; }
	}
}

/*<Codenesium>
    <Hash>1b6ffa9fdb1e57b207a659c5277923e0</Hash>
</Codenesium>*/