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
	public class DeviceActionsController: AbstractDeviceActionsController
	{
		public DeviceActionsController(
			ILogger<DeviceActionsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeviceActionRepository deviceActionRepository,
			IDeviceActionModelValidator deviceActionModelValidator
			) : base(logger,
			         transactionCoordinator,
			         deviceActionRepository,
			         deviceActionModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ed846c9f9fdf834273584da3f93b02f6</Hash>
</Codenesium>*/