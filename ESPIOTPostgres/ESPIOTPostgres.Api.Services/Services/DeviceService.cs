using ESPIOTPostgresNS.Api.Contracts;
using ESPIOTPostgresNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ESPIOTPostgresNS.Api.Services
{
	public partial class DeviceService : AbstractDeviceService, IDeviceService
	{
		public DeviceService(
			ILogger<IDeviceRepository> logger,
			IMediator mediator,
			IDeviceRepository deviceRepository,
			IApiDeviceServerRequestModelValidator deviceModelValidator,
			IDALDeviceMapper dalDeviceMapper,
			IDALDeviceActionMapper dalDeviceActionMapper)
			: base(logger,
			       mediator,
			       deviceRepository,
			       deviceModelValidator,
			       dalDeviceMapper,
			       dalDeviceActionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6dad4bab4090701b11ae0971913399fe</Hash>
</Codenesium>*/