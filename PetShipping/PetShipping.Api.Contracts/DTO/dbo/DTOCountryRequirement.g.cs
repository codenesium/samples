using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class DTOCountryRequirement: AbstractDTO
	{
		public DTOCountryRequirement() : base()
		{}

		public void SetProperties(int id,
		                          int countryId,
		                          string details)
		{
			this.CountryId = countryId.ToInt();
			this.Details = details;
			this.Id = id.ToInt();
		}

		public int CountryId { get; set; }
		public string Details { get; set; }
		public int Id { get; set; }
	}
}

/*<Codenesium>
    <Hash>8f38fb20f0fc8f19bcbec7b31b51d8ef</Hash>
</Codenesium>*/