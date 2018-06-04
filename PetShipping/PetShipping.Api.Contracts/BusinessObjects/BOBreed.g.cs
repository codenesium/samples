using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
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
    <Hash>2cd7045da1e4c28ee3c60781f4a1c743</Hash>
</Codenesium>*/