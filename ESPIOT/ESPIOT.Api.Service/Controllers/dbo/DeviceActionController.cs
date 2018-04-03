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
			ApplicationContext context,
			IDeviceActionRepository deviceActionRepository,
			IDeviceActionModelValidator deviceActionModelValidator
			) : base(logger,
			         context,
			         deviceActionRepository,
			         deviceActionModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1ba4755528b6bf57d5870268f79d825b</Hash>
</Codenesium>*/