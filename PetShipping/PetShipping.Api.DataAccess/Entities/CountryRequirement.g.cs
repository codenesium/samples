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
			int countryId,
			string detail,
			int id)
		{
			this.CountryId = countryId;
			this.Detail = detail;
			this.Id = id;
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
		public virtual Country CountryNavigation { get; private set; }

		public void SetCountryNavigation(Country item)
		{
			this.CountryNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>5819955975c4e87bba7384a5fff8f5b2</Hash>
</Codenesium>*/