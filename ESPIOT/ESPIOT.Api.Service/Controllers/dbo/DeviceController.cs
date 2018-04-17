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
    <Hash>ae3c498532437aac82d3274734fd8051</Hash>
</Codenesium>*/