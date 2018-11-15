using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Web
{
	[Route("api/customers")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class CustomerController : AbstractCustomerController
	{
		public CustomerController(
			ApiSettings settings,
			ILogger<CustomerController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICustomerService customerService,
			IApiCustomerServerModelMapper customerModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       customerService,
			       customerModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d47b650b4e7ab3456efd78a589b30bc0</Hash>
</Codenesium>*/