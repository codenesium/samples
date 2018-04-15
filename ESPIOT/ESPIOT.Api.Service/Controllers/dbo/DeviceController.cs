using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Service
{
	[Route("api/devices")]
	[ApiVersion("1.0")]
	public class DeviceController: AbstractDeviceController
	{
		public DeviceController(
			ILogger<DeviceController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeviceRepository deviceRepository,
			IDeviceModelValidator deviceModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       deviceRepository,
			       deviceModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e6f2ace59c8e2216e716d9497ea578e4</Hash>
</Codenesium>*/