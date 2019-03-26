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
	[Route("api/officerCapabilities")]
	[ApiController]
	[ApiVersion("1.0")]

	public class OfficerCapabilityController : AbstractOfficerCapabilityController
	{
		public OfficerCapabilityController(
			ApiSettings settings,
			ILogger<OfficerCapabilityController> logger,
			ITransactionCoordinator transactionCoordinator,
			IOfficerCapabilityService officerCapabilityService,
			IApiOfficerCapabilityServerModelMapper officerCapabilityModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       officerCapabilityService,
			       officerCapabilityModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>93d012bf3afac5c41cf81ac8dea85627</Hash>
</Codenesium>*/