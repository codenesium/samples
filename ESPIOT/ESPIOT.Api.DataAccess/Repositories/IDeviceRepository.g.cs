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
    <Hash>5312a804343f4ec1ab7280c76b5dcd24</Hash>
</Codenesium>*/