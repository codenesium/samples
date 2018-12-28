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
			IBOLMessengerMapper bolMessengerMapper,
			IDALMessengerMapper dalMessengerMapper)
			: base(logger,
			       mediator,
			       messengerRepository,
			       messengerModelValidator,
			       bolMessengerMapper,
			       dalMessengerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e4b730b64a9c5c912badf57b946a5bcd</Hash>
</Codenesium>*/