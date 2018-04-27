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
	[Route("api/otherTransports")]
	[ApiVersion("1.0")]
	[Response]
	public class OtherTransportController: AbstractOtherTransportController
	{
		public OtherTransportController(
			ServiceSettings settings,
			ILogger<OtherTransportController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOOtherTransport otherTransportManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       otherTransportManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>af2c22821867500410d701a250eee52c</Hash>
</Codenesium>*/