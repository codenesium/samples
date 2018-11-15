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
	[Route("api/clientCommunications")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class ClientCommunicationController : AbstractClientCommunicationController
	{
		public ClientCommunicationController(
			ApiSettings settings,
			ILogger<ClientCommunicationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IClientCommunicationService clientCommunicationService,
			IApiClientCommunicationServerModelMapper clientCommunicationModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       clientCommunicationService,
			       clientCommunicationModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4323406a2e609288b163ac8e13484035</Hash>
</Codenesium>*/