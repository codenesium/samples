using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class MessengerService : AbstractMessengerService, IMessengerService
	{
		public MessengerService(
			ILogger<IMessengerRepository> logger,
			IMessengerRepository messengerRepository,
			IApiMessengerServerRequestModelValidator messengerModelValidator,
			IBOLMessengerMapper bolMessengerMapper,
			IDALMessengerMapper dalMessengerMapper)
			: base(logger,
			       messengerRepository,
			       messengerModelValidator,
			       bolMessengerMapper,
			       dalMessengerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>01b223fb0a5d705205d5ee37857aba17</Hash>
</Codenesium>*/