using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.BusinessObjects;

namespace ESPIOTNS.Api.Service
{
	[Route("api/devices")]
	[ApiVersion("1.0")]
	[Response]
	public class DeviceController: AbstractDeviceController
	{
		public DeviceController(
			ServiceSettings settings,
			ILogger<DeviceController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBODevice deviceManager
			)
			: base(settings,
			       logger,
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
    <Hash>e0585488c4a1ff7164b635e45fcb6719</Hash>
</Codenesium>*/