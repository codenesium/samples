using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetStoreNS.Api.DataAccess
{
	[Table("Pet", Schema="dbo")]
	public partial class Pet:AbstractEntity
	{
		public Pet()
		{}

		public void SetProperties(
			DateTime acquiredDate,
			int breedId,
			string description,
			int id,
			int penId,
			decimal price,
			int speciesId)
		{
			this.AcquiredDate = acquiredDate.ToDateTime();
			this.BreedId = breedId.ToInt();
			this.Description = description;
			this.Id = id.ToInt();
			this.PenId = penId.ToInt();
			this.Price = price.ToDecimal();
			this.SpeciesId = speciesId.ToInt();
		}

		[Column("acquiredDate", TypeName="date")]
		public DateTime AcquiredDate { get; private set; }

		[Column("breedId", TypeName="int")]
		public int BreedId { get; private set; }

		[Column("description", TypeName="text(2147483647)")]
		public string Description { get; private set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("penId", TypeName="int")]
		public int PenId { get; private set; }

		[Column("price", TypeName="money")]
		public decimal Price { get; private set; }

		[Column("speciesId", TypeName="int")]
		public int SpeciesId { get; private set; }

		[ForeignKey("BreedId")]
		public virtual Breed Breed { get; set; }

		[ForeignKey("PenId")]
		public virtual Pen Pen { get; set; }

		[ForeignKey("SpeciesId")]
		public virtual Species Species { get; set; }
	}
}

/*<Codenesium>
    <Hash>6779b2849378ed17d8e8def36e6ceb53</Hash>
</Codenesium>*/