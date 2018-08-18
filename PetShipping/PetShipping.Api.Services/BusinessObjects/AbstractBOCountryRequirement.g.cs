using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBOCountryRequirement : AbstractBusinessObject
	{
		public AbstractBOCountryRequirement()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int countryId,
		                                  string details)
		{
			this.CountryId = countryId;
			this.Details = details;
			this.Id = id;
		}

		public int CountryId { get; private set; }

		public string Details { get; private set; }

		public int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ecd1ce7c3be50cd03c8ea0e5e4af9079</Hash>
</Codenesium>*/