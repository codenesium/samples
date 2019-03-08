using Codenesium.Foundation.CommonMVC;
using ESPIOTPostgresNS.Api.Contracts;
using ESPIOTPostgresNS.Api.Services;
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

namespace ESPIOTPostgresNS.Api.Web
{
	[Route("api/deviceActions")]
	[ApiController]
	[ApiVersion("1.0")]

	public class DeviceActionController : AbstractDeviceActionController
	{
		public DeviceActionController(
			ApiSettings settings,
			ILogger<DeviceActionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeviceActionService deviceActionService,
			IApiDeviceActionServerModelMapper deviceActionModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       deviceActionService,
			       deviceActionModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e05aa1bc847542e1c3fdb088ec69da06</Hash>
</Codenesium>*/