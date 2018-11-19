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
	[Route("api/currencyRates")]
	[ApiController]
	[ApiVersion("1.0")]

	public class CurrencyRateController : AbstractCurrencyRateController
	{
		public CurrencyRateController(
			ApiSettings settings,
			ILogger<CurrencyRateController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICurrencyRateService currencyRateService,
			IApiCurrencyRateServerModelMapper currencyRateModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       currencyRateService,
			       currencyRateModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a41be67c0b7a8a897310919af65e73c2</Hash>
</Codenesium>*/