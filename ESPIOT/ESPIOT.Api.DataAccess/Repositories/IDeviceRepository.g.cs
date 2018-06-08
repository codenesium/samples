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

                Task<List<Device>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<Device> GetPublicId(Guid publicId);
        }
}

/*<Codenesium>
    <Hash>a77a31c8b0974426c8ca643f0df16496</Hash>
</Codenesium>*/