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

		Task<List<DeviceAction>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<DeviceAction>> ByDeviceId(int deviceId, int limit = int.MaxValue, int offset = 0);

		Task<Device> DeviceByDeviceId(int deviceId);
	}
}

/*<Codenesium>
    <Hash>b10cb5d4b96f287019d24d3375e07f97</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/