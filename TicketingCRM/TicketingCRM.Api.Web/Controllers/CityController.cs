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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
	[Route("api/cities")]
	[ApiController]
	[ApiVersion("1.0")]

	public class CityController : AbstractCityController
	{
		public CityController(
			ApiSettings settings,
			ILogger<CityController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICityService cityService,
			IApiCityServerModelMapper cityModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       cityService,
			       cityModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1a47900ec12d81c30436b62470d597ad</Hash>
</Codenesium>*/