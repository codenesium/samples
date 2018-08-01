using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
	public partial class SubscriptionService : AbstractSubscriptionService, ISubscriptionService
	{
		public SubscriptionService(
			ILogger<ISubscriptionRepository> logger,
			ISubscriptionRepository subscriptionRepository,
			IApiSubscriptionRequestModelValidator subscriptionModelValidator,
			IBOLSubscriptionMapper bolsubscriptionMapper,
			IDALSubscriptionMapper dalsubscriptionMapper
			)
			: base(logger,
			       subscriptionRepository,
			       subscriptionModelValidator,
			       bolsubscriptionMapper,
			       dalsubscriptionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7e101a00f4f447a980eae209f0242793</Hash>
</Codenesium>*/