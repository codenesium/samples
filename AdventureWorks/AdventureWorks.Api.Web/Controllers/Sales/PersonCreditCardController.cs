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

namespace AdventureWorksNS.Api.Web
{
	[Route("api/personCreditCards")]
	[ApiController]
	[ApiVersion("1.0")]
	public class PersonCreditCardController : AbstractPersonCreditCardController
	{
		public PersonCreditCardController(
			ApiSettings settings,
			ILogger<PersonCreditCardController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPersonCreditCardService personCreditCardService,
			IApiPersonCreditCardModelMapper personCreditCardModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       personCreditCardService,
			       personCreditCardModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>767bf606f98c09e1ec0db1f2b548819e</Hash>
</Codenesium>*/