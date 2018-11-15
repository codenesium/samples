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
	[Route("api/devices")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class DeviceController : AbstractDeviceController
	{
		public DeviceController(
			ApiSettings settings,
			ILogger<DeviceController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeviceService deviceService,
			IApiDeviceServerModelMapper deviceModelMapper
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
    <Hash>9a25a1e009be33166cd04e63c8d6a67b</Hash>
</Codenesium>*/