using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/people")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class PersonController : AbstractPersonController
	{
		public PersonController(
			ApiSettings settings,
			ILogger<PersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonService personService,
			IApiPersonServerModelMapper personModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       personService,
			       personModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e4b041d5a0b2a24d6d2b121594186ae2</Hash>
</Codenesium>*/