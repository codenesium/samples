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
			string details)
		{
			this.Id = id;
			this.CountryId = countryId;
			this.Details = details;
		}

		[Column("countryId")]
		public virtual int CountryId { get; private set; }

		[MaxLength(2147483647)]
		[Column("details")]
		public virtual string Details { get; private set; }

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
    <Hash>847fb840f1ed1c3c241931fae6ea2801</Hash>
</Codenesium>*/