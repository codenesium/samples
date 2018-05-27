using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;

namespace ESPIOTNS.Api.DataAccess
{
	public interface IDeviceRepository
	{
		Task<DTODevice> Create(DTODevice dto);

		Task Update(int id,
		            DTODevice dto);

		Task Delete(int id);

		Task<DTODevice> Get(int id);

		Task<List<DTODevice>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTODevice> PublicId(Guid publicId);
	}
}

/*<Codenesium>
    <Hash>7d009fbb32e0a737fbdab21106b76cb9</Hash>
</Codenesium>*/