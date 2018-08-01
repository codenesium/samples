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
	[Route("api/contactTypes")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ContactTypeController : AbstractContactTypeController
	{
		public ContactTypeController(
			ApiSettings settings,
			ILogger<ContactTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IContactTypeService contactTypeService,
			IApiContactTypeModelMapper contactTypeModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       contactTypeService,
			       contactTypeModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e82437a342b04df0704bcc539e4795de</Hash>
</Codenesium>*/