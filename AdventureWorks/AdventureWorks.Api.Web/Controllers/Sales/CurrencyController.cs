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
	[Route("api/currencies")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class CurrencyController : AbstractCurrencyController
	{
		public CurrencyController(
			ApiSettings settings,
			ILogger<CurrencyController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICurrencyService currencyService,
			IApiCurrencyServerModelMapper currencyModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       currencyService,
			       currencyModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>be5280f312998ff519c8c6ec4e5bf6a4</Hash>
</Codenesium>*/