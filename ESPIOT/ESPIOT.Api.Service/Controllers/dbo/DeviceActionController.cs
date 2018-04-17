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
	[Route("api/deviceActions")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class DeviceActionController: AbstractDeviceActionController
	{
		public DeviceActionController(
			ILogger<DeviceActionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBODeviceAction deviceActionManager
			)
			: base(logger,
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
    <Hash>16eb47ec2f89845dbce6b7b1c5ef2c7a</Hash>
</Codenesium>*/