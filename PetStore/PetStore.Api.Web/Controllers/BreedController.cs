using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Web
{
	[Route("api/breeds")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

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
    <Hash>4cfe973ab80eaa3aa3db1f41ff25ece8</Hash>
</Codenesium>*/