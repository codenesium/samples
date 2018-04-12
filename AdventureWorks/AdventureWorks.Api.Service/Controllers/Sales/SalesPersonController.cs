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
	public class SalesPersonController: AbstractSalesPersonController
	{
		public SalesPersonController(
			ILogger<SalesPersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesPersonRepository salesPersonRepository,
			ISalesPersonModelValidator salesPersonModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       salesPersonRepository,
			       salesPersonModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>473bd4c4f216c688abd756b2ec1f53e6</Hash>
</Codenesium>*/