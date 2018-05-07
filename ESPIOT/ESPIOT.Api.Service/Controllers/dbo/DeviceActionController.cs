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
	[Route("api/deviceActions")]
	[ApiVersion("1.0")]
	public class DeviceActionController: AbstractDeviceActionController
	{
		public DeviceActionController(
			ServiceSettings settings,
			ILogger<DeviceActionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBODeviceAction deviceActionManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       deviceActionManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a771484ef633c800a011ce16ad08653b</Hash>
</Codenesium>*/