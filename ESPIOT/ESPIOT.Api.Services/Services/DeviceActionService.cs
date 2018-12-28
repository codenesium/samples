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
			IBOLDeviceActionMapper bolDeviceActionMapper,
			IDALDeviceActionMapper dalDeviceActionMapper)
			: base(logger,
			       mediator,
			       deviceActionRepository,
			       deviceActionModelValidator,
			       bolDeviceActionMapper,
			       dalDeviceActionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a22e7c048a092fccd88a0c3cb43636b0</Hash>
</Codenesium>*/