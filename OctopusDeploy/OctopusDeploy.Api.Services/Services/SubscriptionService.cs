using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>a45fa7993d039b1ac9bdd66c3e41bf4c</Hash>
</Codenesium>*/