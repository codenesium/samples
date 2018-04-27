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
	[Route("api/clients")]
	[ApiVersion("1.0")]
	[Response]
	public class ClientController: AbstractClientController
	{
		public ClientController(
			ServiceSettings settings,
			ILogger<ClientController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOClient clientManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       clientManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>22ae5bc9329a381d8b47f35307a5994c</Hash>
</Codenesium>*/