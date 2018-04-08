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
	public class PeopleController: AbstractPeopleController
	{
		public PeopleController(
			ILogger<PeopleController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonRepository personRepository,
			IPersonModelValidator personModelValidator
			) : base(logger,
			         transactionCoordinator,
			         personRepository,
			         personModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a39be87f2984f34f57a790a76390db42</Hash>
</Codenesium>*/