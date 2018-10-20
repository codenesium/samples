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
		public int CountryId { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public string Name { get; private set; }

		[Column("order")]
		public int Order { get; private set; }

		[ForeignKey("CountryId")]
		public virtual Country CountryNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1c751e1cd6f8f73f5f5b84a20f08acef</Hash>
</Codenesium>*/