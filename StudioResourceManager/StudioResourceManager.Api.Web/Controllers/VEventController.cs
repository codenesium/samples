using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Web
{
	[Route("api/vEvents")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class VEventController : AbstractVEventController
	{
		public VEventController(
			ApiSettings settings,
			ILogger<VEventController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVEventService vEventService,
			IApiVEventModelMapper vEventModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       vEventService,
			       vEventModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>67247c38f5dbfd6bc78a98e9df24e5b9</Hash>
</Codenesium>*/