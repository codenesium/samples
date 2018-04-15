using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	[Route("api/studios")]
	[ApiVersion("1.0")]
	public class StudioController: AbstractStudioController
	{
		public StudioController(
			ILogger<StudioController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStudioRepository studioRepository,
			IStudioModelValidator studioModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       studioRepository,
			       studioModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a0400719b1c5034f697e5cdd0e6aab26</Hash>
</Codenesium>*/