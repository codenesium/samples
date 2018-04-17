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
    <Hash>622f89753317f7d69a3faa962a6a0dba</Hash>
</Codenesium>*/