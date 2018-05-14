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
			IApiCountryRegionModelValidator countryRegionModelValidator)
			: base(logger, countryRegionRepository, countryRegionModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>21043700f569918dbdbc787348592f14</Hash>
</Codenesium>*/