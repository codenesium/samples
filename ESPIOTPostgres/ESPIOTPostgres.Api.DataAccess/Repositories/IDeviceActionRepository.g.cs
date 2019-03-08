using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.DataAccess
{
	public partial interface IDeviceActionRepository
	{
		Task<DeviceAction> Create(DeviceAction item);

		Task Update(DeviceAction item);

		Task Delete(int id);

		Task<DeviceAction> Get(int id);

		Task<List<DeviceAction>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<DeviceAction>> ByDeviceId(int deviceId, int limit = int.MaxValue, int offset = 0);

		Task<Device> DeviceByDeviceId(int deviceId);
	}
}

/*<Codenesium>
    <Hash>5bf66976de8080329bf7f45903859ab6</Hash>
</Codenesium>*/