using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.DataAccess
{
        public interface IDeviceRepository
        {
                Task<Device> Create(Device item);

                Task Update(Device item);

                Task Delete(int id);

                Task<Device> Get(int id);

                Task<List<Device>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Device> ByPublicId(Guid publicId);

                Task<List<DeviceAction>> DeviceActions(int deviceId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>41323104c11a7d0fe9aa79d71adab2b1</Hash>
</Codenesium>*/