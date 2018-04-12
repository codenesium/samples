using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	[Route("api/studios")]
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
    <Hash>b945ffb8ec066295c9f0c39c74dcfcc5</Hash>
</Codenesium>*/