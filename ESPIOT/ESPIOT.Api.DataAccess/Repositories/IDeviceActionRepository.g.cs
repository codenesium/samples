using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.DataAccess
{
	public partial interface IDeviceActionRepository
	{
		Task<DeviceAction> Create(DeviceAction item);

		Task Update(DeviceAction item);

		Task Delete(int id);

		Task<DeviceAction> Get(int id);

		Task<List<DeviceAction>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<DeviceAction>> ByDeviceId(int deviceId, int limit = int.MaxValue, int offset = 0);

		Task<Device> DeviceByDeviceId(int deviceId);
	}
}

/*<Codenesium>
    <Hash>e18d25271eaddc2f290b16f05b05d4b8</Hash>
</Codenesium>*/