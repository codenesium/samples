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

	public class VehicleCapabilittyController : AbstractVehicleCapabilittyController
	{
		public VehicleCapabilittyController(
			ApiSettings settings,
			ILogger<VehicleCapabilittyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVehicleCapabilittyService vehicleCapabilittyService,
			IApiVehicleCapabilittyServerModelMapper vehicleCapabilittyModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       vehicleCapabilittyService,
			       vehicleCapabilittyModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c92711610f75c0f92f6e745dd1d62fe1</Hash>
</Codenesium>*/