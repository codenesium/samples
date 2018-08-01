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

namespace PetShippingNS.Api.Web
{
	[Route("api/otherTransports")]
	[ApiController]
	[ApiVersion("1.0")]
	public class OtherTransportController : AbstractOtherTransportController
	{
		public OtherTransportController(
			ApiSettings settings,
			ILogger<OtherTransportController> logger,
			ITransactionCoordinator transactionCoordinator,
			IOtherTransportService otherTransportService,
			IApiOtherTransportModelMapper otherTransportModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       otherTransportService,
			       otherTransportModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>78621ec8fae8f6935af205eec0aea321</Hash>
</Codenesium>*/