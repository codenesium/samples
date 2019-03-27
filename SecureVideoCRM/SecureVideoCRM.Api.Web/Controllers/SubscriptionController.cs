using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Web
{
	[Route("api/subscriptions")]
	[ApiController]
	[ApiVersion("1.0")]

	public class SubscriptionController : AbstractSubscriptionController
	{
		public SubscriptionController(
			ApiSettings settings,
			ILogger<SubscriptionController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISubscriptionService subscriptionService,
			IApiSubscriptionServerModelMapper subscriptionModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       subscriptionService,
			       subscriptionModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>68192195a9630b5c65b7f76d63f7cef4</Hash>
</Codenesium>*/