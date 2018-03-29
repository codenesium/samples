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
			ApplicationContext context,
			ISalesPersonRepository salesPersonRepository,
			ISalesPersonModelValidator salesPersonModelValidator
			) : base(logger,
			         context,
			         salesPersonRepository,
			         salesPersonModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ab5729b875502f801f73d706d80dcef2</Hash>
</Codenesium>*/