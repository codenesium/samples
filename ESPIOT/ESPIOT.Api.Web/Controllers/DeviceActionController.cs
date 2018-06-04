using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.Services;

namespace ESPIOTNS.Api.Web
{
	[Route("api/deviceActions")]
	[ApiVersion("1.0")]
	public class DeviceActionController: AbstractDeviceActionController
	{
		public DeviceActionController(
			ServiceSettings settings,
			ILogger<DeviceActionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeviceActionService deviceActionService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       deviceActionService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f05d28a76806878ad21cedafe2951254</Hash>
</Codenesium>*/