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
			int countryId,
			int id,
			string name,
			int order)
		{
			this.CountryId = countryId;
			this.Id = id;
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
		public virtual Country CountryNavigation { get; private set; }

		public void SetCountryNavigation(Country item)
		{
			this.CountryNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>ad201880ee1b2dad3a3c4aeea83478f8</Hash>
</Codenesium>*/