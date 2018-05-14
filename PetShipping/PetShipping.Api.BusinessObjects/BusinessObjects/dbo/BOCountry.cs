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
			IApiCountryModelValidator countryModelValidator)
			: base(logger, countryRepository, countryModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>237defaec8c515e3d726664bf5fc3b1e</Hash>
</Codenesium>*/