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
    <Hash>e530adcd1d2d213d297dd2637abda537</Hash>
</Codenesium>*/