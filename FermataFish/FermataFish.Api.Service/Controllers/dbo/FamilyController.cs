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
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>1324856e50c88177afa7f648ae02e3cb</Hash>
</Codenesium>*/