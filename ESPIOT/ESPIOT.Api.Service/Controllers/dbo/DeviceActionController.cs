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
	[Route("api/deviceActions")]
	public class DeviceActionController: AbstractDeviceActionController
	{
		public DeviceActionController(
			ILogger<DeviceActionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeviceActionRepository deviceActionRepository,
			IDeviceActionModelValidator deviceActionModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       deviceActionRepository,
			       deviceActionModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b4b187b2707352dd4d77578c2724b128</Hash>
</Codenesium>*/