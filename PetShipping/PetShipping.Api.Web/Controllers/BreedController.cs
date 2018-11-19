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
	[Route("api/breeds")]
	[ApiController]
	[ApiVersion("1.0")]

	public class BreedController : AbstractBreedController
	{
		public BreedController(
			ApiSettings settings,
			ILogger<BreedController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBreedService breedService,
			IApiBreedServerModelMapper breedModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       breedService,
			       breedModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>010d3dc9bbbb457cb521da0616c0fc7a</Hash>
</Codenesium>*/