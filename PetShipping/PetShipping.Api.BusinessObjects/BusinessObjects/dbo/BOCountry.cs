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
			IApiCountryRequestModelValidator countryModelValidator,
			IBOLCountryMapper countryMapper)
			: base(logger, countryRepository, countryModelValidator, countryMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>afc0b7cee166722f84291e8cabd5eb13</Hash>
</Codenesium>*/