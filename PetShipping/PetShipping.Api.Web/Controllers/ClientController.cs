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
    <Hash>eb093c9152bd96e37d565e0e4a82ffec</Hash>
</Codenesium>*/