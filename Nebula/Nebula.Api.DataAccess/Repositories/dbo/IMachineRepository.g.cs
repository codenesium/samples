using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IMachineRepository
	{
		Task<DTOMachine> Create(DTOMachine dto);

		Task Update(int id,
		            DTOMachine dto);

		Task Delete(int id);

		Task<DTOMachine> Get(int id);

		Task<List<DTOMachine>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOMachine> GetMachineGuid(Guid machineGuid);
	}
}

/*<Codenesium>
    <Hash>7da8b78d4e3a5f226c78ebdc05aec78f</Hash>
</Codenesium>*/