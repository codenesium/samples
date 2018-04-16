using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/salesPersons")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(SalesPersonFilter))]
	public class SalesPersonController: AbstractSalesPersonController
	{
		public SalesPersonController(
			ILogger<SalesPersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesPersonRepository salesPersonRepository
			)
			: base(logger,
			       transactionCoordinator,
			       salesPersonRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f24951b410ef5dac771688a0dc85cac2</Hash>
</Codenesium>*/