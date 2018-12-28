using MediatR;
using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class MessageService : AbstractMessageService, IMessageService
	{
		public MessageService(
			ILogger<IMessageRepository> logger,
			IMediator mediator,
			IMessageRepository messageRepository,
			IApiMessageServerRequestModelValidator messageModelValidator,
			IBOLMessageMapper bolMessageMapper,
			IDALMessageMapper dalMessageMapper,
			IBOLMessengerMapper bolMessengerMapper,
			IDALMessengerMapper dalMessengerMapper)
			: base(logger,
			       mediator,
			       messageRepository,
			       messageModelValidator,
			       bolMessageMapper,
			       dalMessageMapper,
			       bolMessengerMapper,
			       dalMessengerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>74e0ab4d9084384ca179847a8d30add9</Hash>
</Codenesium>*/