using ESPIOTPostgresNS.Api.Contracts;
using ESPIOTPostgresNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ESPIOTPostgresNS.Api.Services
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
    <Hash>c00d6e69c6135440761080ba1fa4901c</Hash>
</Codenesium>*/