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

	public class OfficerCapabilitiesController : AbstractOfficerCapabilitiesController
	{
		public OfficerCapabilitiesController(
			ApiSettings settings,
			ILogger<OfficerCapabilitiesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IOfficerCapabilitiesService officerCapabilitiesService,
			IApiOfficerCapabilitiesServerModelMapper officerCapabilitiesModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       officerCapabilitiesService,
			       officerCapabilitiesModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3bd3f5a1ca238007292ff35b2884ae2a</Hash>
</Codenesium>*/