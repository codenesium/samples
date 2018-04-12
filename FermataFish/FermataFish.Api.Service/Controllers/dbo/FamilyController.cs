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
	[Route("api/families")]
	public class FamilyController: AbstractFamilyController
	{
		public FamilyController(
			ILogger<FamilyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFamilyRepository familyRepository,
			IFamilyModelValidator familyModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       familyRepository,
			       familyModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>fedb6673fdfbfc658aa5b5525123f41c</Hash>
</Codenesium>*/