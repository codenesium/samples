using CADNS.Api.Contracts;
using CADNS.Api.Services;
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

namespace CADNS.Api.Web
{
	[Route("api/vehCapabilities")]
	[ApiController]
	[ApiVersion("1.0")]

	public class VehCapabilityController : AbstractVehCapabilityController
	{
		public VehCapabilityController(
			ApiSettings settings,
			ILogger<VehCapabilityController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVehCapabilityService vehCapabilityService,
			IApiVehCapabilityServerModelMapper vehCapabilityModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       vehCapabilityService,
			       vehCapabilityModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4de688f4b1a543fc50c01e52fd869457</Hash>
</Codenesium>*/