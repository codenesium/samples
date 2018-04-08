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
	[Route("api/salesPersons")]
	public class SalesPersonsController: AbstractSalesPersonsController
	{
		public SalesPersonsController(
			ILogger<SalesPersonsController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesPersonRepository salesPersonRepository,
			ISalesPersonModelValidator salesPersonModelValidator
			) : base(logger,
			         transactionCoordinator,
			         salesPersonRepository,
			         salesPersonModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>694e4ee5657bcc8f0dbec1fe0658dc4b</Hash>
</Codenesium>*/