using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("CountryRequirement", Schema="dbo")]
	public partial class EFCountryRequirement: AbstractEntityFrameworkPOCO
	{
		public EFCountryRequirement()
		{}

		public void SetProperties(
			int id,
			int countryId,
			string details)
		{
			this.CountryId = countryId.ToInt();
			this.Details = details.ToString();
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
		public virtual EFCountry Country { get; set; }
	}
}

/*<Codenesium>
    <Hash>9a41e5e4432951aef35255ac871fa7ae</Hash>
</Codenesium>*/