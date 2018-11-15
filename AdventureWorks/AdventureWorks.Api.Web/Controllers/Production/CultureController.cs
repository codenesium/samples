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
	[Route("api/cultures")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class CultureController : AbstractCultureController
	{
		public CultureController(
			ApiSettings settings,
			ILogger<CultureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICultureService cultureService,
			IApiCultureServerModelMapper cultureModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       cultureService,
			       cultureModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c52a258715d6964469a876f2f05f16f9</Hash>
</Codenesium>*/