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
			string email,
			string firstName,
			string lastName,
			string phone,
			Nullable<DateTime> birthday,
			int studioId)
		{
			this.Id = id.ToInt();
			this.Email = email.ToString();
			this.FirstName = firstName.ToString();
			this.LastName = lastName.ToString();
			this.Phone = phone.ToString();
			this.Birthday = birthday.ToNullableDateTime();
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
    <Hash>260813bdb67d582114463c372ed6d4b9</Hash>
</Codenesium>*/