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
	public class PersonCreditCardsController: AbstractPersonCreditCardsController
	{
		public PersonCreditCardsController(
			ILogger<PersonCreditCardsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonCreditCardRepository personCreditCardRepository,
			IPersonCreditCardModelValidator personCreditCardModelValidator
			) : base(logger,
			         transactionCoordinator,
			         personCreditCardRepository,
			         personCreditCardModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>fbbf0aadb5601b4c040ddec64b28791c</Hash>
</Codenesium>*/