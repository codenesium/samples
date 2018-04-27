using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class BOCountry: AbstractBOCountry, IBOCountry
	{
		public BOCountry(
			ILogger<CountryRepository> logger,
			ICountryRepository countryRepository,
			ICountryModelValidator countryModelValidator)
			: base(logger, countryRepository, countryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>e6029801e9ac06ad48372cac51ba1c32</Hash>
</Codenesium>*/