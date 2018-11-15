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
	[Route("api/pets")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class PetController : AbstractPetController
	{
		public PetController(
			ApiSettings settings,
			ILogger<PetController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPetService petService,
			IApiPetServerModelMapper petModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       petService,
			       petModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>cf46d85ae7017f033e1a61453ed7afe0</Hash>
</Codenesium>*/