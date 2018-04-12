using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.Contracts
{
	[Table("Admin", Schema="dbo")]
	public partial class EFAdmin
	{
		public EFAdmin()
		{}

		public void SetProperties(
			int id,
			string email,
			string firstName,
			string lastName,
			string phone,
			Nullable<DateTime> birthday,
			int studioId)
		{
			this.Id = id.ToInt();
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Phone = phone;
			this.Birthday = birthday;
			this.StudioId = studioId.ToInt();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("email", TypeName="varchar(128)")]
		public string Email { get; set; }

		[Column("firstName", TypeName="varchar(128)")]
		public string FirstName { get; set; }

		[Column("lastName", TypeName="varchar(128)")]
		public string LastName { get; set; }

		[Column("phone", TypeName="varchar(128)")]
		public string Phone { get; set; }

		[Column("birthday", TypeName="date")]
		public Nullable<DateTime> Birthday { get; set; }

		[Column("studioId", TypeName="int")]
		public int StudioId { get; set; }

		[ForeignKey("StudioId")]
		public virtual EFStudio Studio { get; set; }
	}
}

/*<Codenesium>
    <Hash>dba452f950fb6a629b920233a475217e</Hash>
</Codenesium>*/