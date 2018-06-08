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
    <Hash>432c40be3d11005b9377d5d3738b3906</Hash>
</Codenesium>*/