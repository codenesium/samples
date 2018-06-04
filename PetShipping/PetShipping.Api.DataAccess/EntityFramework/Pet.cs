using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Pet", Schema="dbo")]
	public partial class Pet:AbstractEntity
	{
		public Pet()
		{}

		public void SetProperties(
			int breedId,
			int clientId,
			int id,
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
		public int BreedId { get; private set; }

		[Column("clientId", TypeName="int")]
		public int ClientId { get; private set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; private set; }

		[Column("weight", TypeName="int")]
		public int Weight { get; private set; }

		[ForeignKey("BreedId")]
		public virtual Breed Breed { get; set; }

		[ForeignKey("ClientId")]
		public virtual Client Client { get; set; }
	}
}

/*<Codenesium>
    <Hash>4bd11a5895cb1f2398fdbdaab7f4079c</Hash>
</Codenesium>*/