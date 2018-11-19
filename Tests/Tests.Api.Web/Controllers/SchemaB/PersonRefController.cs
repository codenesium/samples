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
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;

namespace TestsNS.Api.Web
{
	[Route("api/personRefs")]
	[ApiController]
	[ApiVersion("1.0")]

	public class PersonRefController : AbstractPersonRefController
	{
		public PersonRefController(
			ApiSettings settings,
			ILogger<PersonRefController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonRefService personRefService,
			IApiPersonRefServerModelMapper personRefModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       personRefService,
			       personRefModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>18084598802683000a42dc27be00a4a2</Hash>
</Codenesium>*/