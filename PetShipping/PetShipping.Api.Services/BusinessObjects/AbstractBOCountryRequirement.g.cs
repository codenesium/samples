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
		                                  string detail)
		{
			this.CountryId = countryId;
			this.Detail = detail;
			this.Id = id;
		}

		public int CountryId { get; private set; }

		public string Detail { get; private set; }

		public int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4be9fb61d0701e347f3f93195b85b39b</Hash>
</Codenesium>*/