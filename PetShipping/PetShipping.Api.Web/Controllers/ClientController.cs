using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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
	[Authorize(Policy = "DefaultAccess")]

	public class ClientController : AbstractClientController
	{
		public ClientController(
			ApiSettings settings,
			ILogger<ClientController> logger,
			ITransactionCoordinator transactionCoordinator,
			IClientService clientService,
			IApiClientServerModelMapper clientModelMapper
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
    <Hash>4222d454f87eedb70cbad00f0c2ac566</Hash>
</Codenesium>*/