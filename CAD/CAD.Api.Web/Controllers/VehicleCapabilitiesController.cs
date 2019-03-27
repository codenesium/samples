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

	public class VehicleCapabilitiesController : AbstractVehicleCapabilitiesController
	{
		public VehicleCapabilitiesController(
			ApiSettings settings,
			ILogger<VehicleCapabilitiesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVehicleCapabilitiesService vehicleCapabilitiesService,
			IApiVehicleCapabilitiesServerModelMapper vehicleCapabilitiesModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       vehicleCapabilitiesService,
			       vehicleCapabilitiesModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>fd9b40c2e8da8b72f1103c367cdffb3d</Hash>
</Codenesium>*/