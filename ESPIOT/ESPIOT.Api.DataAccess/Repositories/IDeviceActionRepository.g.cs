using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.DataAccess
{
        public interface IDeviceActionRepository
        {
                Task<DeviceAction> Create(DeviceAction item);

                Task Update(DeviceAction item);

                Task Delete(int id);

                Task<DeviceAction> Get(int id);

                Task<List<DeviceAction>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<DeviceAction>> ByDeviceId(int deviceId);

                Task<Device> GetDevice(int deviceId);
        }
}

/*<Codenesium>
    <Hash>1e61c44ca3ec4f63ab892ed03ffee3fd</Hash>
</Codenesium>*/