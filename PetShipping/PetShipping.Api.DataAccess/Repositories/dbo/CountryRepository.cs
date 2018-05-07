using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public class CountryRepository: AbstractCountryRepository, ICountryRepository
	{
		public CountryRepository(
			IObjectMapper mapper,
			ILogger<CountryRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>de5c138da9799f57b5587a1185f12d8d</Hash>
</Codenesium>*/