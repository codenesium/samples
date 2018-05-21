using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IMachineRepository
	{
		Task<POCOMachine> Create(ApiMachineModel model);

		Task Update(int id,
		            ApiMachineModel model);

		Task Delete(int id);

		Task<POCOMachine> Get(int id);

		Task<List<POCOMachine>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOMachine> GetMachineGuid(Guid machineGuid);
	}
}

/*<Codenesium>
    <Hash>8e15e055ef67e7456af05b94c935fc0a</Hash>
</Codenesium>*/