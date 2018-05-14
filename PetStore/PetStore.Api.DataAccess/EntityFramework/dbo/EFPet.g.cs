using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetStoreNS.Api.DataAccess
{
	[Table("Pet", Schema="dbo")]
	public partial class Pet:AbstractEntityFrameworkPOCO
	{
		public Pet()
		{}

		public void SetProperties(
			int id,
			DateTime acquiredDate,
			int breedId,
			string description,
			int penId,
			decimal price,
			int speciesId)
		{
			this.AcquiredDate = acquiredDate.ToDateTime();
			this.BreedId = breedId.ToInt();
			this.Description = description.ToString();
			this.Id = id.ToInt();
			this.PenId = penId.ToInt();
			this.Price = price.ToDecimal();
			this.SpeciesId = speciesId.ToInt();
		}

		[Column("acquiredDate", TypeName="date")]
		public DateTime AcquiredDate { get; set; }

		[Column("breedId", TypeName="int")]
		public int BreedId { get; set; }

		[Column("description", TypeName="text(2147483647)")]
		public string Description { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("penId", TypeName="int")]
		public int PenId { get; set; }

		[Column("price", TypeName="money")]
		public decimal Price { get; set; }

		[Column("speciesId", TypeName="int")]
		public int SpeciesId { get; set; }

		[ForeignKey("BreedId")]
		public virtual Breed Breed { get; set; }

		[ForeignKey("PenId")]
		public virtual Pen Pen { get; set; }

		[ForeignKey("SpeciesId")]
		public virtual Species Species { get; set; }
	}
}

/*<Codenesium>
    <Hash>b4d6559f1862113730c607eb56d1537b</Hash>
</Codenesium>*/