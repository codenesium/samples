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
	[Route("api/officerRefCapabilities")]
	[ApiController]
	[ApiVersion("1.0")]

	public class OfficerRefCapabilityController : AbstractOfficerRefCapabilityController
	{
		public OfficerRefCapabilityController(
			ApiSettings settings,
			ILogger<OfficerRefCapabilityController> logger,
			ITransactionCoordinator transactionCoordinator,
			IOfficerRefCapabilityService officerRefCapabilityService,
			IApiOfficerRefCapabilityServerModelMapper officerRefCapabilityModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       officerRefCapabilityService,
			       officerRefCapabilityModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>94b0f32a59d31826ca8d915dfcad95cf</Hash>
</Codenesium>*/