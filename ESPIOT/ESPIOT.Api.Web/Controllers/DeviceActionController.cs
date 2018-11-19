using Codenesium.Foundation.CommonMVC;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.Services;
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

namespace ESPIOTNS.Api.Web
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
    <Hash>6b4a77ac0bf61018f7d4690a9fa10bb7</Hash>
</Codenesium>*/