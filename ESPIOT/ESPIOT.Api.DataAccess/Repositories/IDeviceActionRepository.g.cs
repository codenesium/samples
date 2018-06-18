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

                Task<List<DeviceAction>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<DeviceAction>> ByDeviceId(int deviceId);

                Task<Device> GetDevice(int deviceId);
        }
}

/*<Codenesium>
    <Hash>34fc9c7f5f372df8558c8c920ecec9a5</Hash>
</Codenesium>*/