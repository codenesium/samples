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
			IApiPersonRefModelMapper personRefModelMapper
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
    <Hash>4b54f03ae9b8a36d424c8b2195f10685</Hash>
</Codenesium>*/