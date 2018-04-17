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
	[Route("api/personCreditCards")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class PersonCreditCardController: AbstractPersonCreditCardController
	{
		public PersonCreditCardController(
			ILogger<PersonCreditCardController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPersonCreditCard personCreditCardManager
			)
			: base(logger,
			       transactionCoordinator,
			       personCreditCardManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9f5ac6832cb3333d5f90be77d27202a9</Hash>
</Codenesium>*/