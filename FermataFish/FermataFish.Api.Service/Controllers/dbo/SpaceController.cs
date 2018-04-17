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
	[Route("api/spaces")]
	[ApiVersion("1.0")]
	public class SpaceController: AbstractSpaceController
	{
		public SpaceController(
			ILogger<SpaceController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSpace spaceManager
			)
			: base(logger,
			       transactionCoordinator,
			       spaceManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f5519d1df57ef177127a622a642a8d61</Hash>
</Codenesium>*/