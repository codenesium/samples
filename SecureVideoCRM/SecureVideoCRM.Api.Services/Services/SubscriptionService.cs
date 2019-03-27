using MediatR;
using Microsoft.Extensions.Logging;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;

namespace SecureVideoCRMNS.Api.Services
{
	public partial class SubscriptionService : AbstractSubscriptionService, ISubscriptionService
	{
		public SubscriptionService(
			ILogger<ISubscriptionRepository> logger,
			IMediator mediator,
			ISubscriptionRepository subscriptionRepository,
			IApiSubscriptionServerRequestModelValidator subscriptionModelValidator,
			IDALSubscriptionMapper dalSubscriptionMapper)
			: base(logger,
			       mediator,
			       subscriptionRepository,
			       subscriptionModelValidator,
			       dalSubscriptionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>428f811614e56c301b55fb43ec97e3a7</Hash>
</Codenesium>*/