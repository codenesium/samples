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

namespace ESPIOTNS.Api.Web
{
	[Route("api/devices")]
	[ApiController]
	[ApiVersion("1.0")]
	public class DeviceController : AbstractDeviceController
	{
		public DeviceController(
			ApiSettings settings,
			ILogger<DeviceController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeviceService deviceService,
			IApiDeviceModelMapper deviceModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       deviceService,
			       deviceModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e51b5af0eebd627ebdc1e34cfd00499a</Hash>
</Codenesium>*/