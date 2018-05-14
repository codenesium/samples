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

		POCOMachine Get(int id);

		List<POCOMachine> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOMachine MachineGuid(Guid machineGuid);
	}
}

/*<Codenesium>
    <Hash>5ddcd5c59b0c1f935c2fe0ea65c221a9</Hash>
</Codenesium>*/