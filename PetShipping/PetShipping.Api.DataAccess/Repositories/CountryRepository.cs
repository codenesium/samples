using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
	public class CountryRepository: AbstractCountryRepository, ICountryRepository
	{
		public CountryRepository(
			ILogger<CountryRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>013bf35419ace70fcae311abc4f02c9f</Hash>
</Codenesium>*/