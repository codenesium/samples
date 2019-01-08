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
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;

namespace TestsNS.Api.Web
{
	[Route("api/vPersons")]
	[ApiController]
	[ApiVersion("1.0")]

	public class VPersonController : AbstractVPersonController
	{
		public VPersonController(
			ApiSettings settings,
			ILogger<VPersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVPersonService vPersonService,
			IApiVPersonServerModelMapper vPersonModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       vPersonService,
			       vPersonModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ecdc271bc0b1d7a1ee6f1638d7396395</Hash>
</Codenesium>*/