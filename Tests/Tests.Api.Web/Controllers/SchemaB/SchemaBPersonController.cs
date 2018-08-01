using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;

namespace TestsNS.Api.Web
{
	[Route("api/schemaBPersons")]
	[ApiController]
	[ApiVersion("1.0")]
	public class SchemaBPersonController : AbstractSchemaBPersonController
	{
		public SchemaBPersonController(
			ApiSettings settings,
			ILogger<SchemaBPersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISchemaBPersonService schemaBPersonService,
			IApiSchemaBPersonModelMapper schemaBPersonModelMapper
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
    <Hash>2beacae96711c569017cb3fb7d50072d</Hash>
</Codenesium>*/