using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.Services;

namespace PetStoreNS.Api.Web
{
	[Route("api/pens")]
	[ApiVersion("1.0")]
	public class PenController: AbstractPenController
	{
		public PenController(
			ServiceSettings settings,
			ILogger<PenController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPenService penService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       penService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>028a3900d92c6b7bc7cc849c9b0b31e4</Hash>
</Codenesium>*/