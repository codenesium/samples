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
    <Hash>75b9f9406a1ff61b382a4fd97e66331d</Hash>
</Codenesium>*/