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
	[Route("api/contactTypes")]
	[ApiVersion("1.0")]
	public class ContactTypeController: AbstractContactTypeController
	{
		public ContactTypeController(
			ServiceSettings settings,
			ILogger<ContactTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IContactTypeService contactTypeService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       contactTypeService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>bb99125aeccd2833f497e70db71fa5b5</Hash>
</Codenesium>*/