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
	[Route("api/deviceActions")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(DeviceActionFilter))]
	public class DeviceActionController: AbstractDeviceActionController
	{
		public DeviceActionController(
			ILogger<DeviceActionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeviceActionRepository deviceActionRepository
			)
			: base(logger,
			       transactionCoordinator,
			       deviceActionRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a546e0e963f515e901a446333b096f1b</Hash>
</Codenesium>*/