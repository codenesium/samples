using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TicketingCRMNS.Api.DataAccess
{
	[Table("Province", Schema="dbo")]
	public partial class Province : AbstractEntity
	{
		public Province()
		{
		}

		public virtual void SetProperties(
			int id,
			int countryId,
			string name)
		{
			this.Id = id;
			this.CountryId = countryId;
			this.Name = name;
		}

		[Column("countryId")]
		public virtual int CountryId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[ForeignKey("CountryId")]
		public virtual Country CountryIdNavigation { get; private set; }

		public void SetCountryIdNavigation(Country item)
		{
			this.CountryIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>5269bcda8aa543cf2f78eb0bea963081</Hash>
</Codenesium>*/