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
	[Route("api/creditCards")]
	public class CreditCardsController: AbstractCreditCardsController
	{
		public CreditCardsController(
			ILogger<CreditCardsController> logger,
			ApplicationContext context,
			ICreditCardRepository creditCardRepository,
			ICreditCardModelValidator creditCardModelValidator
			) : base(logger,
			         context,
			         creditCardRepository,
			         creditCardModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>df6825e54f9509d6518dccee81b58728</Hash>
</Codenesium>*/