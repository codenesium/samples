using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class DTOBreed: AbstractDTO
	{
		public DTOBreed() : base()
		{}

		public void SetProperties(int id,
		                          string name,
		                          int speciesId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.SpeciesId = speciesId.ToInt();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public int SpeciesId { get; set; }
	}
}

/*<Codenesium>
    <Hash>77c6c08c8035cec47edcef8fa7877306</Hash>
</Codenesium>*/