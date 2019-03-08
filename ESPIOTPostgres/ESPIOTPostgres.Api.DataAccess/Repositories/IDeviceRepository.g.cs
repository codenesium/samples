using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.DataAccess
{
	public partial interface IDeviceRepository
	{
		Task<Device> Create(Device item);

		Task Update(Device item);

		Task Delete(int id);

		Task<Device> Get(int id);

		Task<List<Device>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Device> ByPublicId(Guid publicId);

		Task<List<DeviceAction>> DeviceActionsByDeviceId(int deviceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>156219e6a77ac9fdbb83481c857a16d8</Hash>
</Codenesium>*/