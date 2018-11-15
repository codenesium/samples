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
	[Route("api/customerCommunications")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class CustomerCommunicationController : AbstractCustomerCommunicationController
	{
		public CustomerCommunicationController(
			ApiSettings settings,
			ILogger<CustomerCommunicationController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICustomerCommunicationService customerCommunicationService,
			IApiCustomerCommunicationServerModelMapper customerCommunicationModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       customerCommunicationService,
			       customerCommunicationModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>369235189bb8625d708a64ad7ed5b97a</Hash>
</Codenesium>*/