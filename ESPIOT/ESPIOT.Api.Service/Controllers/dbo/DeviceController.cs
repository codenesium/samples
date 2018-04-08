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
	public class DevicesController: AbstractDevicesController
	{
		public DevicesController(
			ILogger<DevicesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDeviceRepository deviceRepository,
			IDeviceModelValidator deviceModelValidator
			) : base(logger,
			         transactionCoordinator,
			         deviceRepository,
			         deviceModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0292efe1cdc97cc07d0f46f33896b521</Hash>
</Codenesium>*/