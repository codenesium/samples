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
			IDALCountryMapper mapper,
			ILogger<CountryRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>e92598dcf006a6248a1f9b5c59b7c43f</Hash>
</Codenesium>*/