using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Destination", Schema="dbo")]
	public partial class Destination: AbstractEntity
	{
		public Destination()
		{}

		public void SetProperties(
			int countryId,
			int id,
			string name,
			int order)
		{
			this.CountryId = countryId.ToInt();
			this.Id = id.ToInt();
			this.Name = name;
			this.Order = order.ToInt();
		}

		[Column("countryId", TypeName="int")]
		public int CountryId { get; private set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; private set; }

		[Column("order", TypeName="int")]
		public int Order { get; private set; }

		[ForeignKey("CountryId")]
		public virtual Country Country { get; set; }
	}
}

/*<Codenesium>
    <Hash>dcb964b2d13dfb8a7004e95a9c162d00</Hash>
</Codenesium>*/