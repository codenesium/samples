using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Service
{
	[Route("api/devices")]
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
    <Hash>aa81830b4b5c32b9fb5842540a30a43c</Hash>
</Codenesium>*/