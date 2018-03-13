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
	public class DevicesController: DevicesControllerAbstract
	{
		public DevicesController(
			ILogger<DevicesController> logger,
			ApplicationContext context,
			DeviceRepository deviceRepository,
			DeviceModelValidator deviceModelValidator
			) : base(logger,
			         context,
			         deviceRepository,
			         deviceModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>fa866ffde2e52b35804a17d1ee6209e6</Hash>
</Codenesium>*/