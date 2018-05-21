using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOMachine
	{
		Task<CreateResponse<POCOMachine>> Create(
			ApiMachineModel model);

		Task<ActionResponse> Update(int id,
		                            ApiMachineModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOMachine> Get(int id);

		Task<List<POCOMachine>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOMachine> GetMachineGuid(Guid machineGuid);
	}
}

/*<Codenesium>
    <Hash>44a6aafa884b357b8eeb9bbdcb85daff</Hash>
</Codenesium>*/