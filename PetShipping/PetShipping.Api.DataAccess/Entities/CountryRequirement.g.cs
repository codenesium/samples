using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("CountryRequirement", Schema="dbo")]
	public partial class CountryRequirement : AbstractEntity
	{
		public CountryRequirement()
		{
		}

		public virtual void SetProperties(
			int id,
			int countryId,
			string detail)
		{
			this.Id = id;
			this.CountryId = countryId;
			this.Detail = detail;
		}

		[Column("countryId")]
		public virtual int CountryId { get; private set; }

		[MaxLength(2147483647)]
		[Column("details")]
		public virtual string Detail { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[ForeignKey("CountryId")]
		public virtual Country CountryIdNavigation { get; private set; }

		public void SetCountryIdNavigation(Country item)
		{
			this.CountryIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>ed986319b2cade3c10e5682bc7ba47b7</Hash>
</Codenesium>*/