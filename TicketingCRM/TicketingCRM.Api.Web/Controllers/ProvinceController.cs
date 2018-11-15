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
	[Route("api/provinces")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class ProvinceController : AbstractProvinceController
	{
		public ProvinceController(
			ApiSettings settings,
			ILogger<ProvinceController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProvinceService provinceService,
			IApiProvinceServerModelMapper provinceModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       provinceService,
			       provinceModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8dbebe6e361ac021adef84e105fa804e</Hash>
</Codenesium>*/