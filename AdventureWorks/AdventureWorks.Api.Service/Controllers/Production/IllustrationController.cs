using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	[Route("api/illustrations")]
	public class IllustrationsController: AbstractIllustrationsController
	{
		public IllustrationsController(
			ILogger<IllustrationsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IIllustrationRepository illustrationRepository,
			IIllustrationModelValidator illustrationModelValidator
			) : base(logger,
			         transactionCoordinator,
			         illustrationRepository,
			         illustrationModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>33172793758538e1c25fbcad4683ce33</Hash>
</Codenesium>*/