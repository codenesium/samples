using MediatR;
using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class MessengerService : AbstractMessengerService, IMessengerService
	{
		public MessengerService(
			ILogger<IMessengerRepository> logger,
			IMediator mediator,
			IMessengerRepository messengerRepository,
			IApiMessengerServerRequestModelValidator messengerModelValidator,
			IDALMessengerMapper dalMessengerMapper)
			: base(logger,
			       mediator,
			       messengerRepository,
			       messengerModelValidator,
			       dalMessengerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5e5dfff9dcd845e65b96bc3b77121561</Hash>
</Codenesium>*/