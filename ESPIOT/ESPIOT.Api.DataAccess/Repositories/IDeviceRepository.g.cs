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

                Task<List<Device>> All(int limit = int.MaxValue, int offset = 0);

                Task<Device> ByPublicId(Guid publicId);

                Task<List<DeviceAction>> DeviceActions(int deviceId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>691756e2ad417efa11d6c4674724bf3d</Hash>
</Codenesium>*/