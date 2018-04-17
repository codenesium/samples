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
	[Route("api/families")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class FamilyController: AbstractFamilyController
	{
		public FamilyController(
			ILogger<FamilyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOFamily familyManager
			)
			: base(logger,
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
    <Hash>3790f35781cc7cddacf651211bba058c</Hash>
</Codenesium>*/