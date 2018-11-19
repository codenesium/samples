using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Web
{
	[Route("api/handlers")]
	[ApiController]
	[ApiVersion("1.0")]

	public class HandlerController : AbstractHandlerController
	{
		public HandlerController(
			ApiSettings settings,
			ILogger<HandlerController> logger,
			ITransactionCoordinator transactionCoordinator,
			IHandlerService handlerService,
			IApiHandlerServerModelMapper handlerModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       handlerService,
			       handlerModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>70caa5975e36067795b732510509adc7</Hash>
</Codenesium>*/