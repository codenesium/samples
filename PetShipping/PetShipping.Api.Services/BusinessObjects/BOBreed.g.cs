using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
	public partial class BOBreed: AbstractBusinessObject
	{
		public BOBreed() : base()
		{}

		public void SetProperties(int id,
		                          string name,
		                          int speciesId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.SpeciesId = speciesId.ToInt();
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public int SpeciesId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>755ad5ea12dfb31a0788ff58de0f5da5</Hash>
</Codenesium>*/