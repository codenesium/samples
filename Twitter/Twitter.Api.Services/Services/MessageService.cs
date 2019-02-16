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
			IDALMessageMapper dalMessageMapper,
			IDALMessengerMapper dalMessengerMapper)
			: base(logger,
			       mediator,
			       messageRepository,
			       messageModelValidator,
			       dalMessageMapper,
			       dalMessengerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>49c7d7acebff7912a990216f79fd03bd</Hash>
</Codenesium>*/