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
	[Route("api/vehicles")]
	[ApiController]
	[ApiVersion("1.0")]

	public class VehicleController : AbstractVehicleController
	{
		public VehicleController(
			ApiSettings settings,
			ILogger<VehicleController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVehicleService vehicleService,
			IApiVehicleServerModelMapper vehicleModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       vehicleService,
			       vehicleModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>864329bf6f449f72ba186fbe9cecc853</Hash>
</Codenesium>*/