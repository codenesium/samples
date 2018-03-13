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
			DeviceActionRepository deviceActionRepository,
			DeviceActionModelValidator deviceActionModelValidator
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
    <Hash>ad261d28873e3dce828e4b83a4f01c82</Hash>
</Codenesium>*/