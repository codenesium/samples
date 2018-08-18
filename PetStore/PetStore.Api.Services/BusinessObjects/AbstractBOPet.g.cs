using Codenesium.DataConversionExtensions;
using System;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractBOPet : AbstractBusinessObject
	{
		public AbstractBOPet()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  DateTime acquiredDate,
		                                  int breedId,
		                                  string description,
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

		public DateTime AcquiredDate { get; private set; }

		public int BreedId { get; private set; }

		public string Description { get; private set; }

		public int Id { get; private set; }

		public int PenId { get; private set; }

		public decimal Price { get; private set; }

		public int SpeciesId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0855aa90eda0a06a0be7889041433b42</Hash>
</Codenesium>*/