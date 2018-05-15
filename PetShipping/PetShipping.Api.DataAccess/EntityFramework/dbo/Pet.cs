using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Pet", Schema="dbo")]
	public partial class Pet:AbstractEntityFrameworkPOCO
	{
		public Pet()
		{}

		public void SetProperties(
			int id,
			int breedId,
			int clientId,
			string name,
			int weight)
		{
			this.BreedId = breedId.ToInt();
			this.ClientId = clientId.ToInt();
			this.Id = id.ToInt();
			this.Name = name;
			this.Weight = weight.ToInt();
		}

		[Column("breedId", TypeName="int")]
		public int BreedId { get; set; }

		[Column("clientId", TypeName="int")]
		public int ClientId { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }

		[Column("weight", TypeName="int")]
		public int Weight { get; set; }

		[ForeignKey("BreedId")]
		public virtual Breed Breed { get; set; }

		[ForeignKey("ClientId")]
		public virtual Client Client { get; set; }
	}
}

/*<Codenesium>
    <Hash>01c0d57401a9485f9b25e0222b17d773</Hash>
</Codenesium>*/