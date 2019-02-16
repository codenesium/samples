using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Destination", Schema="dbo")]
	public partial class Destination : AbstractEntity
	{
		public Destination()
		{
		}

		public virtual void SetProperties(
			int id,
			int countryId,
			string name,
			int order)
		{
			this.Id = id;
			this.CountryId = countryId;
			this.Name = name;
			this.Order = order;
		}

		[Column("countryId")]
		public virtual int CountryId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[Column("order")]
		public virtual int Order { get; private set; }

		[ForeignKey("CountryId")]
		public virtual Country CountryIdNavigation { get; private set; }

		public void SetCountryIdNavigation(Country item)
		{
			this.CountryIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>0309949bf04b57b742d15948be9f0819</Hash>
</Codenesium>*/