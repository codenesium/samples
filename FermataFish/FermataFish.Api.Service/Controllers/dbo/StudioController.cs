using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.BusinessObjects;

namespace FermataFishNS.Api.Service
{
	[Route("api/studios")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class StudioController: AbstractStudioController
	{
		public StudioController(
			ILogger<StudioController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOStudio studioManager
			)
			: base(logger,
			       transactionCoordinator,
			       studioManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9b39a7d3788e32992b070a5e22028da6</Hash>
</Codenesium>*/