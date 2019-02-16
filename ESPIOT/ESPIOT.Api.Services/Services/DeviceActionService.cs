using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ESPIOTNS.Api.Services
{
	public partial class DeviceActionService : AbstractDeviceActionService, IDeviceActionService
	{
		public DeviceActionService(
			ILogger<IDeviceActionRepository> logger,
			IMediator mediator,
			IDeviceActionRepository deviceActionRepository,
			IApiDeviceActionServerRequestModelValidator deviceActionModelValidator,
			IDALDeviceActionMapper dalDeviceActionMapper)
			: base(logger,
			       mediator,
			       deviceActionRepository,
			       deviceActionModelValidator,
			       dalDeviceActionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6d46c89c18f006e389a7c29c26735922</Hash>
</Codenesium>*/