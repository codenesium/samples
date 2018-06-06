using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
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
    <Hash>cdcf32c9106573ebc0168356abc75473</Hash>
</Codenesium>*/