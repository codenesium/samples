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
	[Route("api/vehicleOfficers")]
	[ApiController]
	[ApiVersion("1.0")]

	public class VehicleOfficerController : AbstractVehicleOfficerController
	{
		public VehicleOfficerController(
			ApiSettings settings,
			ILogger<VehicleOfficerController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVehicleOfficerService vehicleOfficerService,
			IApiVehicleOfficerServerModelMapper vehicleOfficerModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       vehicleOfficerService,
			       vehicleOfficerModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c1b4c0f064624a30b976c3fbe985ef7b</Hash>
</Codenesium>*/