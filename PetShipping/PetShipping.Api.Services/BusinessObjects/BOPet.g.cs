using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
	public partial class BOPet:AbstractBusinessObject
	{
		public BOPet() : base()
		{}

		public void SetProperties(int id,
		                          int breedId,
		                          int clientId,
		                          string name,
		                          int weight)
		{
			this.BreedId = breedId.ToInt();
			this.ClientId = clientId.ToInt();
			this.Id = id.ToInt();
			this.Name = name;
			this.Weight = weight.ToInt();
		}

		public int BreedId { get; private set; }
		public int ClientId { get; private set; }
		public int Id { get; private set; }
		public string Name { get; private set; }
		public int Weight { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d1ed673277e49fa4d6db3a50eacc4fa3</Hash>
</Codenesium>*/