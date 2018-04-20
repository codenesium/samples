using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/people")]
	[ApiVersion("1.0")]
	[Response]
	public class PersonController: AbstractPersonController
	{
		public PersonController(
			ServiceSettings settings,
			ILogger<PersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPerson personManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       personManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>41074d52b7c270a5d12e2728a9c3f0bb</Hash>
</Codenesium>*/