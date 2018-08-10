using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/schemaVersions")]
	[ApiController]
	[ApiVersion("1.0")]
	public class SchemaVersionsController : AbstractSchemaVersionsController
	{
		public SchemaVersionsController(
			ApiSettings settings,
			ILogger<SchemaVersionsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISchemaVersionsService schemaVersionsService,
			IApiSchemaVersionsModelMapper schemaVersionsModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       schemaVersionsService,
			       schemaVersionsModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0469c5c9a91707ee3bf942fddf467ff4</Hash>
</Codenesium>*/