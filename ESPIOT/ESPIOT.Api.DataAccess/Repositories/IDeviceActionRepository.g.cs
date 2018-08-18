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

		Task<Device> GetDevice(int deviceId);
	}
}

/*<Codenesium>
    <Hash>e06a6bcc8997db3d8bbbfb424d39f0b4</Hash>
</Codenesium>*/