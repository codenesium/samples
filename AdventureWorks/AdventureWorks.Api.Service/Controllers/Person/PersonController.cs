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
	[Route("api/people")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(PersonFilter))]
	public class PersonController: AbstractPersonController
	{
		public PersonController(
			ILogger<PersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonRepository personRepository
			)
			: base(logger,
			       transactionCoordinator,
			       personRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2a3de68a29283fa4e42c1bccdc88c1ee</Hash>
</Codenesium>*/