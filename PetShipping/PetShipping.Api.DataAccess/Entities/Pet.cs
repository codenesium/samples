using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Pet", Schema="dbo")]
	public partial class Pet : AbstractEntity
	{
		public Pet()
		{
		}

		public virtual void SetProperties(
			int id,
			int breedId,
			int clientId,
			string name,
			int weight)
		{
			this.Id = id;
			this.BreedId = breedId;
			this.ClientId = clientId;
			this.Name = name;
			this.Weight = weight;
		}

		[Column("breedId")]
		public virtual int BreedId { get; private set; }

		[Column("clientId")]
		public virtual int ClientId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[Column("weight")]
		public virtual int Weight { get; private set; }

		[ForeignKey("BreedId")]
		public virtual Breed BreedIdNavigation { get; private set; }

		public void SetBreedIdNavigation(Breed item)
		{
			this.BreedIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>a90a85dfe433d6dabb9b3f8248949d23</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/