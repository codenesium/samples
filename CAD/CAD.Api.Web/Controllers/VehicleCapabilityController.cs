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
	[Route("api/vehicleCapabilities")]
	[ApiController]
	[ApiVersion("1.0")]

	public class VehicleCapabilityController : AbstractVehicleCapabilityController
	{
		public VehicleCapabilityController(
			ApiSettings settings,
			ILogger<VehicleCapabilityController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVehicleCapabilityService vehicleCapabilityService,
			IApiVehicleCapabilityServerModelMapper vehicleCapabilityModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       vehicleCapabilityService,
			       vehicleCapabilityModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>97929d739db7a62e03ffbeb2fe88f85f</Hash>
</Codenesium>*/