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
	public class DeviceActionsController: DeviceActionsControllerAbstract
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
    <Hash>92e124e2b652e610b7f3e9813fea23c8</Hash>
</Codenesium>*/