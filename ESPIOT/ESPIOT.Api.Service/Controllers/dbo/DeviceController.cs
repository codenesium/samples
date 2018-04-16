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
	[ServiceFilter(typeof(DeviceFilter))]
	public class DeviceController: AbstractDeviceController
	{
		public DeviceController(
			ILogger<DeviceController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeviceRepository deviceRepository
			)
			: base(logger,
			       transactionCoordinator,
			       deviceRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e9ea5bd2e7daa491e80798f3e17b355c</Hash>
</Codenesium>*/