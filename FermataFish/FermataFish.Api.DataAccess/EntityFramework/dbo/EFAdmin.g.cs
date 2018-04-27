using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Admin", Schema="dbo")]
	public partial class EFAdmin: AbstractEntityFrameworkPOCO
	{
		public EFAdmin()
		{}

		public void SetProperties(
			int id,
			Nullable<DateTime> birthday,
			string email,
			string firstName,
			string lastName,
			string phone,
			int studioId)
		{
			this.Birthday = birthday.ToNullableDateTime();
			this.Email = email.ToString();
			this.FirstName = firstName.ToString();
			this.Id = id.ToInt();
			this.LastName = lastName.ToString();
			this.Phone = phone.ToString();
			this.StudioId = studioId.ToInt();
		}

		[Column("birthday", TypeName="date")]
		public Nullable<DateTime> Birthday { get; set; }

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
		public virtual EFStudio Studio { get; set; }
	}
}

/*<Codenesium>
    <Hash>9aac30a53d371f02950618c11d5fff4b</Hash>
</Codenesium>*/