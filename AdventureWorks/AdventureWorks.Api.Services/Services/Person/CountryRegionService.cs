using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial class CountryRegionService : AbstractCountryRegionService, ICountryRegionService
	{
		public CountryRegionService(
			ILogger<ICountryRegionRepository> logger,
			ICountryRegionRepository countryRegionRepository,
			IApiCountryRegionRequestModelValidator countryRegionModelValidator,
			IBOLCountryRegionMapper bolcountryRegionMapper,
			IDALCountryRegionMapper dalcountryRegionMapper,
			IBOLStateProvinceMapper bolStateProvinceMapper,
			IDALStateProvinceMapper dalStateProvinceMapper
			)
			: base(logger,
			       countryRegionRepository,
			       countryRegionModelValidator,
			       bolcountryRegionMapper,
			       dalcountryRegionMapper,
			       bolStateProvinceMapper,
			       dalStateProvinceMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5888f8d589f624d4bb830aae2e71adba</Hash>
</Codenesium>*/