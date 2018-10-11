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
			IDALVStateProvinceCountryRegionMapper dalvStateProvinceCountryRegionMapper)
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
    <Hash>98b35297c985495584cb576ec681d4f5</Hash>
</Codenesium>*/