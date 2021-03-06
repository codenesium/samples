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

		Task<List<Device>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Device> ByPublicId(Guid publicId);

		Task<List<DeviceAction>> DeviceActionsByDeviceId(int deviceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c07f1f08d155b516feb0d6ed4fdf146e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/