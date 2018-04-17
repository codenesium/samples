using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/people")]
	[ApiVersion("1.0")]
	public class PersonController: AbstractPersonController
	{
		public PersonController(
			ILogger<PersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPerson personManager
			)
			: base(logger,
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
    <Hash>cb7a298abcfa273d954da54ebf43d595</Hash>
</Codenesium>*/