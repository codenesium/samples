using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class CountryService: AbstractCountryService, ICountryService
	{
		public CountryService(
			ILogger<CountryRepository> logger,
			ICountryRepository countryRepository,
			IApiCountryRequestModelValidator countryModelValidator,
			IBOLCountryMapper BOLcountryMapper,
			IDALCountryMapper DALcountryMapper)
			: base(logger, countryRepository,
			       countryModelValidator,
			       BOLcountryMapper,
			       DALcountryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>0ed7d893ffd54ffb8dd34bb87145194e</Hash>
</Codenesium>*/