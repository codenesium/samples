using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Contracts
{
	public partial class DTOPet:AbstractDTO
	{
		public DTOPet() : base()
		{}

		public void SetProperties(int id,
		                          DateTime acquiredDate,
		                          int breedId,
		                          string description,
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

		public DateTime AcquiredDate { get; set; }
		public int BreedId { get; set; }
		public string Description { get; set; }
		public int Id { get; set; }
		public int PenId { get; set; }
		public decimal Price { get; set; }
		public int SpeciesId { get; set; }
	}
}

/*<Codenesium>
    <Hash>18e22b0aafa9ea2053ba223d1f08efd4</Hash>
</Codenesium>*/