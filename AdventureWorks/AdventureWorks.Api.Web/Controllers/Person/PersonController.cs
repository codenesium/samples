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
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/people")]
	[ApiVersion("1.0")]
	public class PersonController: AbstractPersonController
	{
		public PersonController(
			ServiceSettings settings,
			ILogger<PersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonService personService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       personService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>144c97dc6538c171e5a08d3ab2f88501</Hash>
</Codenesium>*/