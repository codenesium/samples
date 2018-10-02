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
	public partial class VStateProvinceCountryRegionService : AbstractVStateProvinceCountryRegionService, IVStateProvinceCountryRegionService
	{
		public VStateProvinceCountryRegionService(
			ILogger<IVStateProvinceCountryRegionRepository> logger,
			IVStateProvinceCountryRegionRepository vStateProvinceCountryRegionRepository,
			IApiVStateProvinceCountryRegionRequestModelValidator vStateProvinceCountryRegionModelValidator,
			IBOLVStateProvinceCountryRegionMapper bolvStateProvinceCountryRegionMapper,
			IDALVStateProvinceCountryRegionMapper dalvStateProvinceCountryRegionMapper
			)
			: base(logger,
			       vStateProvinceCountryRegionRepository,
			       vStateProvinceCountryRegionModelValidator,
			       bolvStateProvinceCountryRegionMapper,
			       dalvStateProvinceCountryRegionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>193b1458aeb602ad6fdc5366464eb098</Hash>
</Codenesium>*/