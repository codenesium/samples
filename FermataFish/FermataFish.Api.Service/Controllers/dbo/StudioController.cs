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
	[ServiceFilter(typeof(StudioFilter))]
	public class StudioController: AbstractStudioController
	{
		public StudioController(
			ILogger<StudioController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStudioRepository studioRepository
			)
			: base(logger,
			       transactionCoordinator,
			       studioRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5f53b5dacd03d5cf950e5f08cef317e1</Hash>
</Codenesium>*/