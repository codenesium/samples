using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.BusinessObjects;

namespace FermataFishNS.Api.Service
{
	[Route("api/studios")]
	[ApiVersion("1.0")]
	[Response]
	public class StudioController: AbstractStudioController
	{
		public StudioController(
			ServiceSettings settings,
			ILogger<StudioController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOStudio studioManager
			)
			: base(settings,
			       logger,
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
    <Hash>9c8d808accccb592ba652f033fc16155</Hash>
</Codenesium>*/