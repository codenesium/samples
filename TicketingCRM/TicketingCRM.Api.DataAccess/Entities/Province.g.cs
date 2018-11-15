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
			int countryId,
			int id,
			string name)
		{
			this.CountryId = countryId;
			this.Id = id;
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
		public virtual Country CountryNavigation { get; private set; }

		public void SetCountryNavigation(Country item)
		{
			this.CountryNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>e074a84e9f51d953507962b67d09063f</Hash>
</Codenesium>*/