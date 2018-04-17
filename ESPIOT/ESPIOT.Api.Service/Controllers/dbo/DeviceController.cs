using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.BusinessObjects;

namespace ESPIOTNS.Api.Service
{
	[Route("api/devices")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class DeviceController: AbstractDeviceController
	{
		public DeviceController(
			ILogger<DeviceController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBODevice deviceManager
			)
			: base(logger,
			       transactionCoordinator,
			       deviceManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3b7592b49f4d63976b907a4a7a6c036e</Hash>
</Codenesium>*/