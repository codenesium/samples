using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.DataAccess
{
	public partial interface IDeviceRepository
	{
		Task<Device> Create(Device item);

		Task Update(Device item);

		Task Delete(int id);

		Task<Device> Get(int id);

		Task<List<Device>> All(int limit = int.MaxValue, int offset = 0);

		Task<Device> ByPublicId(Guid publicId);

		Task<List<DeviceAction>> DeviceActions(int deviceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>dec28c62df07ee0941a0f0e27c594c62</Hash>
</Codenesium>*/