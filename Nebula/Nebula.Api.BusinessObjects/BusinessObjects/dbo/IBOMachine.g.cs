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

		Task<POCOMachine> MachineGuid(Guid machineGuid);
	}
}

/*<Codenesium>
    <Hash>9282c5773a3a0909c3213845c946c894</Hash>
</Codenesium>*/