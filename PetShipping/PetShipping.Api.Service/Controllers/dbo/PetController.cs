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
	[Route("api/pets")]
	[ApiVersion("1.0")]
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
    <Hash>71cf3b82cd6e96170efc225609b47337</Hash>
</Codenesium>*/