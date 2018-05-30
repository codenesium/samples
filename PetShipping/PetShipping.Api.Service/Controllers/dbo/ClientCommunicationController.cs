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
	[Route("api/clientCommunications")]
	[ApiVersion("1.0")]
	public class ClientCommunicationController: AbstractClientCommunicationController
	{
		public ClientCommunicationController(
			ServiceSettings settings,
			ILogger<ClientCommunicationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOClientCommunication clientCommunicationManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       clientCommunicationManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ac956943591ec2cac52771a60f3b2436</Hash>
</Codenesium>*/