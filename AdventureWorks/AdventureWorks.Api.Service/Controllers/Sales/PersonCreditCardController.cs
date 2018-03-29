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
			ApplicationContext context,
			IPersonCreditCardRepository personCreditCardRepository,
			IPersonCreditCardModelValidator personCreditCardModelValidator
			) : base(logger,
			         context,
			         personCreditCardRepository,
			         personCreditCardModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f4438395498c21a01f3520867d4070dd</Hash>
</Codenesium>*/