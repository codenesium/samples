using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;

namespace TestsNS.Api.Web
{
	[Route("api/people")]
	[ApiController]
	[ApiVersion("1.0")]
	public class PersonController : AbstractPersonController
	{
		public PersonController(
			ApiSettings settings,
			ILogger<PersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonService personService,
			IApiPersonModelMapper personModelMapper
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
    <Hash>f97a69242b0d9992908daecb3978d4e5</Hash>
</Codenesium>*/