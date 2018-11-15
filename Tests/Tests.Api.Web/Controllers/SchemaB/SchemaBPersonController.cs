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
	[Route("api/schemaBPersons")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class SchemaBPersonController : AbstractSchemaBPersonController
	{
		public SchemaBPersonController(
			ApiSettings settings,
			ILogger<SchemaBPersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISchemaBPersonService schemaBPersonService,
			IApiSchemaBPersonServerModelMapper schemaBPersonModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       schemaBPersonService,
			       schemaBPersonModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>181d29558c1139dc5721743e47b025b1</Hash>
</Codenesium>*/