using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/cultures")]
	[ApiController]
	[ApiVersion("1.0")]
	public class CultureController : AbstractCultureController
	{
		public CultureController(
			ApiSettings settings,
			ILogger<CultureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICultureService cultureService,
			IApiCultureModelMapper cultureModelMapper
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
    <Hash>fb093c5404b20b4e905e0e2b3dddeef1</Hash>
</Codenesium>*/