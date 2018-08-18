using Codenesium.Foundation.CommonMVC;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.Services;
using FluentValidation.Results;
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
			IApiDeviceActionModelMapper deviceActionModelMapper
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
    <Hash>4226eab64ce9d9fb14bea18ac91985c2</Hash>
</Codenesium>*/