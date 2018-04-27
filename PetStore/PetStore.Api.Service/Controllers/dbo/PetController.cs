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
using PetStoreNS.Api.BusinessObjects;

namespace PetStoreNS.Api.Service
{
	[Route("api/pets")]
	[ApiVersion("1.0")]
	[Response]
	public class PetController: AbstractPetController
	{
		public PetController(
			ServiceSettings settings,
			ILogger<PetController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOPet petManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       petManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>df0ef8d0ac96ca90accb8ed71fc50197</Hash>
</Codenesium>*/