using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public class CountryRegionRepository: AbstractCountryRegionRepository, ICountryRegionRepository
	{
		public CountryRegionRepository(
			IDALCountryRegionMapper mapper,
			ILogger<CountryRegionRepository> logger,
			ApplicationDbContext context)
			: base(mapper, logger, context)
		{}
	}
}

/*<Codenesium>
    <Hash>75acc39af2d086a4f3e20788247bc6f0</Hash>
</Codenesium>*/