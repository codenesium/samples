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
			int id,
			DateTime acquiredDate,
			int breedId,
			string description,
			int penId,
			decimal price)
		{
			this.Id = id;
			this.AcquiredDate = acquiredDate;
			this.BreedId = breedId;
			this.Description = description;
			this.PenId = penId;
			this.Price = price;
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

		[ForeignKey("BreedId")]
		public virtual Breed BreedIdNavigation { get; private set; }

		public void SetBreedIdNavigation(Breed item)
		{
			this.BreedIdNavigation = item;
		}

		[ForeignKey("PenId")]
		public virtual Pen PenIdNavigation { get; private set; }

		public void SetPenIdNavigation(Pen item)
		{
			this.PenIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>75a21e3ef8e65f8b6db2a9c3b4974bd1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/