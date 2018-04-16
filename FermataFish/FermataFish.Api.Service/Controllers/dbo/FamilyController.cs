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
	[Route("api/families")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(FamilyFilter))]
	public class FamilyController: AbstractFamilyController
	{
		public FamilyController(
			ILogger<FamilyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFamilyRepository familyRepository
			)
			: base(logger,
			       transactionCoordinator,
			       familyRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>cac297c9eb957cb571957e1944bfe69f</Hash>
</Codenesium>*/