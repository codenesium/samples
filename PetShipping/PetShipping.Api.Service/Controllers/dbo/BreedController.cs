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
using PetShippingNS.Api.BusinessObjects;

namespace PetShippingNS.Api.Service
{
	[Route("api/breeds")]
	[ApiVersion("1.0")]
	[Response]
	public class BreedController: AbstractBreedController
	{
		public BreedController(
			ServiceSettings settings,
			ILogger<BreedController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOBreed breedManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       breedManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>bbf7ba1008f9331b23f8a6bd630c0208</Hash>
</Codenesium>*/