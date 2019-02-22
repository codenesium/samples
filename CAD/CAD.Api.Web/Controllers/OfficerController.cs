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
	[Route("api/officers")]
	[ApiController]
	[ApiVersion("1.0")]

	public class OfficerController : AbstractOfficerController
	{
		public OfficerController(
			ApiSettings settings,
			ILogger<OfficerController> logger,
			ITransactionCoordinator transactionCoordinator,
			IOfficerService officerService,
			IApiOfficerServerModelMapper officerModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       officerService,
			       officerModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>51b7119de4cc83f3940cfe1b3d915fb1</Hash>
</Codenesium>*/