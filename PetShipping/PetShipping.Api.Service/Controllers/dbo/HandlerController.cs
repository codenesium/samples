using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.BusinessObjects;

namespace PetShippingNS.Api.Service
{
	[Route("api/handlers")]
	[ApiVersion("1.0")]
	[Response]
	public class HandlerController: AbstractHandlerController
	{
		public HandlerController(
			ServiceSettings settings,
			ILogger<HandlerController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOHandler handlerManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       handlerManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>bb7547c741b79cd9db68ebf7fdeb277b</Hash>
</Codenesium>*/