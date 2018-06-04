using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.DataAccess
{
	public interface IDeviceActionRepository
	{
		Task<DeviceAction> Create(DeviceAction item);

		Task Update(DeviceAction item);

		Task Delete(int id);

		Task<DeviceAction> Get(int id);

		Task<List<DeviceAction>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DeviceAction>> GetDeviceId(int deviceId);
	}
}

/*<Codenesium>
    <Hash>516d1c2ef92bda581e361f8cc0a353fb</Hash>
</Codenesium>*/