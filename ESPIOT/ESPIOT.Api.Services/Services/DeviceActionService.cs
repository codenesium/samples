using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace ESPIOTNS.Api.Services
{
	public partial class DeviceActionService : AbstractDeviceActionService, IDeviceActionService
	{
		public DeviceActionService(
			ILogger<IDeviceActionRepository> logger,
			IDeviceActionRepository deviceActionRepository,
			IApiDeviceActionServerRequestModelValidator deviceActionModelValidator,
			IBOLDeviceActionMapper bolDeviceActionMapper,
			IDALDeviceActionMapper dalDeviceActionMapper)
			: base(logger,
			       deviceActionRepository,
			       deviceActionModelValidator,
			       bolDeviceActionMapper,
			       dalDeviceActionMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>213147630fa948fe1ab1499c35efc822</Hash>
</Codenesium>*/