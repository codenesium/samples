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
			IDALSubscriptionMapper dalSubscriptionMapper,
			IDALUserMapper dalUserMapper)
			: base(logger,
			       mediator,
			       subscriptionRepository,
			       subscriptionModelValidator,
			       dalSubscriptionMapper,
			       dalUserMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>635bca69511109823a014bc9daa81330</Hash>
</Codenesium>*/