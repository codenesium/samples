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
	[Route("api/personCreditCards")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(PersonCreditCardFilter))]
	public class PersonCreditCardController: AbstractPersonCreditCardController
	{
		public PersonCreditCardController(
			ILogger<PersonCreditCardController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonCreditCardRepository personCreditCardRepository
			)
			: base(logger,
			       transactionCoordinator,
			       personCreditCardRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>29688b6e24aa09a9c3f5a7c2bbd9424d</Hash>
</Codenesium>*/