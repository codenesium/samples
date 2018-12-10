using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NebulaNS.Api.Web
{
	[Route("api/clasps")]
	[ApiController]
	[ApiVersion("1.0")]

	public class ClaspController : AbstractClaspController
	{
		public ClaspController(
			ApiSettings settings,
			ILogger<ClaspController> logger,
			ITransactionCoordinator transactionCoordinator,
			IClaspService claspService,
			IApiClaspServerModelMapper claspModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       claspService,
			       claspModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>64f6d7bfe60b505ec03fc7e3551e656c</Hash>
</Codenesium>*/