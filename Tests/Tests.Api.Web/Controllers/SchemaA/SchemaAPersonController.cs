using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
	[Route("api/schemaAPersons")]
	[ApiController]
	[ApiVersion("1.0")]
	public class SchemaAPersonController : AbstractSchemaAPersonController
	{
		public SchemaAPersonController(
			ApiSettings settings,
			ILogger<SchemaAPersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISchemaAPersonService schemaAPersonService,
			IApiSchemaAPersonModelMapper schemaAPersonModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       schemaAPersonService,
			       schemaAPersonModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>bab9e05254e992f473da2fe95c15ce6a</Hash>
</Codenesium>*/