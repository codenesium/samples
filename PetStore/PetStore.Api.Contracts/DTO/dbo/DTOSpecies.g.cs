using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Contracts
{
	public partial class DTOSpecies: AbstractDTO
	{
		public DTOSpecies() : base()
		{}

		public void SetProperties(int id,
		                          string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		public int Id { get; set; }
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>ec46b1951bd76d246dc04a15d3b549f6</Hash>
</Codenesium>*/