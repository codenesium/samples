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
	[Route("api/people")]
	public class PersonController: AbstractPersonController
	{
		public PersonController(
			ILogger<PersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonRepository personRepository,
			IPersonModelValidator personModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       personRepository,
			       personModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d6d40cf198cbc7659ccf1e387c6cddd6</Hash>
</Codenesium>*/