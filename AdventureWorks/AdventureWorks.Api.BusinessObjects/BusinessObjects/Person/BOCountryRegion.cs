using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOCountryRegion: AbstractBOCountryRegion, IBOCountryRegion
	{
		public BOCountryRegion(
			ILogger<CountryRegionRepository> logger,
			ICountryRegionRepository countryRegionRepository,
			ICountryRegionModelValidator countryRegionModelValidator)
			: base(logger, countryRegionRepository, countryRegionModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>3e8c6f52391c05d1479a9074eb8f407f</Hash>
</Codenesium>*/