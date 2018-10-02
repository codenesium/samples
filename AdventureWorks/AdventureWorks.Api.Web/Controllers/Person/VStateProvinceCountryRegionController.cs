using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/vStateProvinceCountryRegions")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class VStateProvinceCountryRegionController : AbstractVStateProvinceCountryRegionController
	{
		public VStateProvinceCountryRegionController(
			ApiSettings settings,
			ILogger<VStateProvinceCountryRegionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVStateProvinceCountryRegionService vStateProvinceCountryRegionService,
			IApiVStateProvinceCountryRegionModelMapper vStateProvinceCountryRegionModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       vStateProvinceCountryRegionService,
			       vStateProvinceCountryRegionModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>32c193336e186a479dcbd32c6d35fecc</Hash>
</Codenesium>*/