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

		Task<POCOMachine> MachineGuid(Guid machineGuid);
	}
}

/*<Codenesium>
    <Hash>36bd010f0aa95c7da62d28c83e40ad86</Hash>
</Codenesium>*/