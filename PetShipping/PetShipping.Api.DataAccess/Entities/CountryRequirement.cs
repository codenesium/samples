using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("CountryRequirement", Schema="dbo")]
	public partial class CountryRequirement: AbstractEntity
	{
		public CountryRequirement()
		{}

		public void SetProperties(
			int countryId,
			string details,
			int id)
		{
			this.CountryId = countryId.ToInt();
			this.Details = details;
			this.Id = id.ToInt();
		}

		[Column("countryId", TypeName="int")]
		public int CountryId { get; private set; }

		[Column("details", TypeName="text(2147483647)")]
		public string Details { get; private set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[ForeignKey("CountryId")]
		public virtual Country Country { get; set; }
	}
}

/*<Codenesium>
    <Hash>9df6b9f6dd463079041c6984c8614be5</Hash>
</Codenesium>*/