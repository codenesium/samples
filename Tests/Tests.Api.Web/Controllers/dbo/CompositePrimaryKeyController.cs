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
	[Route("api/compositePrimaryKeys")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class CompositePrimaryKeyController : AbstractCompositePrimaryKeyController
	{
		public CompositePrimaryKeyController(
			ApiSettings settings,
			ILogger<CompositePrimaryKeyController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICompositePrimaryKeyService compositePrimaryKeyService,
			IApiCompositePrimaryKeyModelMapper compositePrimaryKeyModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       compositePrimaryKeyService,
			       compositePrimaryKeyModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4d389748ad145fd5dc68a85c32f66554</Hash>
</Codenesium>*/