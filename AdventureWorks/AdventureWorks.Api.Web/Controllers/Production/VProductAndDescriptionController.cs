using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
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

namespace AdventureWorksNS.Api.Web
{
	[Route("api/vProductAndDescriptions")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class VProductAndDescriptionController : AbstractVProductAndDescriptionController
	{
		public VProductAndDescriptionController(
			ApiSettings settings,
			ILogger<VProductAndDescriptionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVProductAndDescriptionService vProductAndDescriptionService,
			IApiVProductAndDescriptionModelMapper vProductAndDescriptionModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       vProductAndDescriptionService,
			       vProductAndDescriptionModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>60e7417abf7b96b83fa59596a0614f5e</Hash>
</Codenesium>*/