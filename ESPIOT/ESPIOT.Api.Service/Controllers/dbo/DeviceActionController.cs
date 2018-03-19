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
    <Hash>7f1c41aec1247a9f5cf861e27019eea8</Hash>
</Codenesium>*/