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
	[Route("api/personCreditCards")]
	public class PersonCreditCardController: AbstractPersonCreditCardController
	{
		public PersonCreditCardController(
			ILogger<PersonCreditCardController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonCreditCardRepository personCreditCardRepository,
			IPersonCreditCardModelValidator personCreditCardModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       personCreditCardRepository,
			       personCreditCardModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7dfc881fd9b3d3f9847d3b67b04419c3</Hash>
</Codenesium>*/