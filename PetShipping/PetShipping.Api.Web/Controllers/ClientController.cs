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
	[Route("api/clients")]
	[ApiController]
	[ApiVersion("1.0")]
	public class ClientController : AbstractClientController
	{
		public ClientController(
			ApiSettings settings,
			ILogger<ClientController> logger,
			ITransactionCoordinator transactionCoordinator,
			IClientService clientService,
			IApiClientModelMapper clientModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       clientService,
			       clientModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ca7d67ee7766fa65842881f4e9f973e2</Hash>
</Codenesium>*/