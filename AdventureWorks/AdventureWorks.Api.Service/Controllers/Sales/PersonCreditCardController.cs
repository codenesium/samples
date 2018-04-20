using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/personCreditCards")]
	[ApiVersion("1.0")]
	[Response]
	public class PersonCreditCardController: AbstractPersonCreditCardController
	{
		public PersonCreditCardController(
			ServiceSettings settings,
			ILogger<PersonCreditCardController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPersonCreditCard personCreditCardManager
			)
			: base(settings,
			       logger,
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
    <Hash>791081b3336c6acfb5a094048312039a</Hash>
</Codenesium>*/