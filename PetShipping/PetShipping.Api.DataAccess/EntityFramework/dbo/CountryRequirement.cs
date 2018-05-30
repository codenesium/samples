using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("CountryRequirement", Schema="dbo")]
	public partial class CountryRequirement: AbstractEntityFrameworkDTO
	{
		public CountryRequirement()
		{}

		public void SetProperties(
			int id,
			int countryId,
			string details)
		{
			this.CountryId = countryId.ToInt();
			this.Details = details;
			this.Id = id.ToInt();
		}

		[Column("countryId", TypeName="int")]
		public int CountryId { get; set; }

		[Column("details", TypeName="text(2147483647)")]
		public string Details { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[ForeignKey("CountryId")]
		public virtual Country Country { get; set; }
	}
}

/*<Codenesium>
    <Hash>64b3a2a70cb40747b22151b77ed01d04</Hash>
</Codenesium>*/