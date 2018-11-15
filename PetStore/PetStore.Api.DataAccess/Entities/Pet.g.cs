using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetStoreNS.Api.DataAccess
{
	[Table("Pet", Schema="dbo")]
	public partial class Pet : AbstractEntity
	{
		public Pet()
		{
		}

		public virtual void SetProperties(
			DateTime acquiredDate,
			int breedId,
			string description,
			int id,
			int penId,
			decimal price,
			int speciesId)
		{
			this.AcquiredDate = acquiredDate;
			this.BreedId = breedId;
			this.Description = description;
			this.Id = id;
			this.PenId = penId;
			this.Price = price;
			this.SpeciesId = speciesId;
		}

		[Column("acquiredDate")]
		public virtual DateTime AcquiredDate { get; private set; }

		[Column("breedId")]
		public virtual int BreedId { get; private set; }

		[MaxLength(2147483647)]
		[Column("description")]
		public virtual string Description { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("penId")]
		public virtual int PenId { get; private set; }

		[Column("price")]
		public virtual decimal Price { get; private set; }

		[Column("speciesId")]
		public virtual int SpeciesId { get; private set; }

		[ForeignKey("BreedId")]
		public virtual Breed BreedNavigation { get; private set; }

		public void SetBreedNavigation(Breed item)
		{
			this.BreedNavigation = item;
		}

		[ForeignKey("PenId")]
		public virtual Pen PenNavigation { get; private set; }

		public void SetPenNavigation(Pen item)
		{
			this.PenNavigation = item;
		}

		[ForeignKey("SpeciesId")]
		public virtual Species SpeciesNavigation { get; private set; }

		public void SetSpeciesNavigation(Species item)
		{
			this.SpeciesNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>58da41b94852eae9dc8ccb0ef059fb90</Hash>
</Codenesium>*/