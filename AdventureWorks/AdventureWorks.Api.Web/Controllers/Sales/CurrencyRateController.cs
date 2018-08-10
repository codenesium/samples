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
			IApiCurrencyRateModelMapper currencyRateModelMapper
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
    <Hash>aabb7aa5c7f91d85a7623347d211ba86</Hash>
</Codenesium>*/