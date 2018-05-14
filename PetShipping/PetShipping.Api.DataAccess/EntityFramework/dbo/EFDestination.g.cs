using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Destination", Schema="dbo")]
	public partial class Destination: AbstractEntityFrameworkPOCO
	{
		public Destination()
		{}

		public void SetProperties(
			int id,
			int countryId,
			string name,
			int order)
		{
			this.CountryId = countryId.ToInt();
			this.Id = id.ToInt();
			this.Name = name.ToString();
			this.Order = order.ToInt();
		}

		[Column("countryId", TypeName="int")]
		public int CountryId { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }

		[Column("order", TypeName="int")]
		public int Order { get; set; }

		[ForeignKey("CountryId")]
		public virtual Country Country { get; set; }
	}
}

/*<Codenesium>
    <Hash>96d05c1ba2996e9e5ebf26b7a47581cf</Hash>
</Codenesium>*/