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
    <Hash>2818810fd74dfbe752d26dd6b66d4fa1</Hash>
</Codenesium>*/