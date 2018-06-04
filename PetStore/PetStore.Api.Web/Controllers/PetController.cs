using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.Services;

namespace PetStoreNS.Api.Web
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
    <Hash>a65bca7845bd3ce4aeaa4e6f7c7b9d3a</Hash>
</Codenesium>*/