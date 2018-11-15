using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class MessageService : AbstractMessageService, IMessageService
	{
		public MessageService(
			ILogger<IMessageRepository> logger,
			IMessageRepository messageRepository,
			IApiMessageServerRequestModelValidator messageModelValidator,
			IBOLMessageMapper bolMessageMapper,
			IDALMessageMapper dalMessageMapper,
			IBOLMessengerMapper bolMessengerMapper,
			IDALMessengerMapper dalMessengerMapper)
			: base(logger,
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
    <Hash>032da9d0ea8dc9f115fff8698f36201d</Hash>
</Codenesium>*/