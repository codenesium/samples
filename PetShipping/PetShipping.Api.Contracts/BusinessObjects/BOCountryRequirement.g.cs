using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class BOCountryRequirement: AbstractBusinessObject
	{
		public BOCountryRequirement() : base()
		{}

		public void SetProperties(int id,
		                          int countryId,
		                          string details)
		{
			this.CountryId = countryId.ToInt();
			this.Details = details;
			this.Id = id.ToInt();
		}

		public int CountryId { get; private set; }
		public string Details { get; private set; }
		public int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>be52b74b017e851e6452dd147946a787</Hash>
</Codenesium>*/