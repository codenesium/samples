using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Web
{
	[Route("api/pets")]
	[ApiVersion("1.0")]
	public class PetController: AbstractPetController
	{
		public PetController(
			ServiceSettings settings,
			ILogger<PetController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPetService petService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       petService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>38c05a5d995fbbcf732acdd6e05a6178</Hash>
</Codenesium>*/