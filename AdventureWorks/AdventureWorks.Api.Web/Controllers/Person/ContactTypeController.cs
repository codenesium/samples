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
	[Route("api/contactTypes")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class ContactTypeController : AbstractContactTypeController
	{
		public ContactTypeController(
			ApiSettings settings,
			ILogger<ContactTypeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IContactTypeService contactTypeService,
			IApiContactTypeServerModelMapper contactTypeModelMapper
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
    <Hash>9d04d53ba08a7ec14771c781a6fadc8a</Hash>
</Codenesium>*/