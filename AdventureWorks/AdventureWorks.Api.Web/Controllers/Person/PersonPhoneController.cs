using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
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

namespace AdventureWorksNS.Api.Web
{
	[Route("api/personPhones")]
	[ApiController]
	[ApiVersion("1.0")]
	public class PersonPhoneController : AbstractPersonPhoneController
	{
		public PersonPhoneController(
			ApiSettings settings,
			ILogger<PersonPhoneController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonPhoneService personPhoneService,
			IApiPersonPhoneModelMapper personPhoneModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       personPhoneService,
			       personPhoneModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2e3ab3b0200c31e52a97544a454c08c2</Hash>
</Codenesium>*/