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
    <Hash>9db77d45094275044110b0d351015d75</Hash>
</Codenesium>*/