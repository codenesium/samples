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
	[Route("api/schemaAPersons")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
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
    <Hash>65c1454d7e251529c332d1a0fb436ec1</Hash>
</Codenesium>*/