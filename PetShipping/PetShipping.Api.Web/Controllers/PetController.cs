using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
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
	[Route("api/pets")]
	[ApiController]
	[ApiVersion("1.0")]
	public class PetController : AbstractPetController
	{
		public PetController(
			ApiSettings settings,
			ILogger<PetController> logger,
			ITransactionCoordinator transactionCoordinator,
			IPetService petService,
			IApiPetModelMapper petModelMapper
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
    <Hash>ac94514836ae6671201969977c3b01eb</Hash>
</Codenesium>*/