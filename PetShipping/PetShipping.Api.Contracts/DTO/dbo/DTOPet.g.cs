using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class DTOPet:AbstractDTO
	{
		public DTOPet() : base()
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

		public int BreedId { get; set; }
		public int ClientId { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public int Weight { get; set; }
	}
}

/*<Codenesium>
    <Hash>a93a72edd4dfccec7d9fc07a7f3724d2</Hash>
</Codenesium>*/