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

                Task<List<DeviceAction>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<DeviceAction>> ByDeviceId(int deviceId);
        }
}

/*<Codenesium>
    <Hash>12207b38c2508dbaa0ccd3c048ac9b05</Hash>
</Codenesium>*/