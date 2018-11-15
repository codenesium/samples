using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace ESPIOTNS.Api.Services
{
	public partial class DeviceService : AbstractDeviceService, IDeviceService
	{
		public DeviceService(
			ILogger<IDeviceRepository> logger,
			IDeviceRepository deviceRepository,
			IApiDeviceServerRequestModelValidator deviceModelValidator,
			IBOLDeviceMapper bolDeviceMapper,
			IDALDeviceMapper dalDeviceMapper,
			IBOLDeviceActionMapper bolDeviceActionMapper,
			IDALDeviceActionMapper dalDeviceActionMapper)
			: base(logger,
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
    <Hash>fcaf3102369713d216949d9e53935da8</Hash>
</Codenesium>*/