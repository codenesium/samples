using CADNS.Api.Contracts;
using CADNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CADNS.Api.Web
{
	[Route("api/offCapabilities")]
	[ApiController]
	[ApiVersion("1.0")]

	public class OffCapabilityController : AbstractOffCapabilityController
	{
		public OffCapabilityController(
			ApiSettings settings,
			ILogger<OffCapabilityController> logger,
			ITransactionCoordinator transactionCoordinator,
			IOffCapabilityService offCapabilityService,
			IApiOffCapabilityServerModelMapper offCapabilityModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       offCapabilityService,
			       offCapabilityModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a5867630e63ee174ca8d34b2e81b86c1</Hash>
</Codenesium>*/