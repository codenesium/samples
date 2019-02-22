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
	[Route("api/vehicleRefCapabilities")]
	[ApiController]
	[ApiVersion("1.0")]

	public class VehicleRefCapabilityController : AbstractVehicleRefCapabilityController
	{
		public VehicleRefCapabilityController(
			ApiSettings settings,
			ILogger<VehicleRefCapabilityController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVehicleRefCapabilityService vehicleRefCapabilityService,
			IApiVehicleRefCapabilityServerModelMapper vehicleRefCapabilityModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       vehicleRefCapabilityService,
			       vehicleRefCapabilityModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>36841e5778447f6ccfad6469c8cfe7c7</Hash>
</Codenesium>*/