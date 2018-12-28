using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ESPIOTNS.Api.Services
{
	public partial class DeviceService : AbstractDeviceService, IDeviceService
	{
		public DeviceService(
			ILogger<IDeviceRepository> logger,
			IMediator mediator,
			IDeviceRepository deviceRepository,
			IApiDeviceServerRequestModelValidator deviceModelValidator,
			IBOLDeviceMapper bolDeviceMapper,
			IDALDeviceMapper dalDeviceMapper,
			IBOLDeviceActionMapper bolDeviceActionMapper,
			IDALDeviceActionMapper dalDeviceActionMapper)
			: base(logger,
			       mediator,
			       deviceRepository,
			       deviceModelValidator,
			       bolDeviceMapper,
			       dalDeviceMapper,
			       bolDeviceActionMapper,
			       dalDeviceActionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d93b908b10b8a63c9a394ced4131b56a</Hash>
</Codenesium>*/