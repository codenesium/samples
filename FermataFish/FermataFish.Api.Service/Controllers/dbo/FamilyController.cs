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
	[Route("api/families")]
	[ApiVersion("1.0")]
	[Response]
	public class FamilyController: AbstractFamilyController
	{
		public FamilyController(
			ServiceSettings settings,
			ILogger<FamilyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOFamily familyManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       familyManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>cc22553f54c56119cdc42ad9d2d106fa</Hash>
</Codenesium>*/