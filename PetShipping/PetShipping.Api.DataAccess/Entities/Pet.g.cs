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
			int breedId,
			int clientId,
			int id,
			string name,
			int weight)
		{
			this.BreedId = breedId;
			this.ClientId = clientId;
			this.Id = id;
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
		public virtual Breed BreedNavigation { get; private set; }

		public void SetBreedNavigation(Breed item)
		{
			this.BreedNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>ce4234756f3737f0cf6cc8ad32da4f2b</Hash>
</Codenesium>*/